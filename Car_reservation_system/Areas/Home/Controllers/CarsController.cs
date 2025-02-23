﻿using Car_reservation_system.Exceptions;
using Car_reservation_system.Models;
using Car_reservation_system.Repositories.IRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Car_reservation_system.Areas.Home.Controllers
{
    public class CarsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CarsController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await _unitOfWork.Car.GetAllDtoAsync());
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id, string? returnUrl)
        {
            TempData["ReturnUrl"] = returnUrl ??= "/";
            var car = await _unitOfWork
                .Car
                .GetFirstOrDefaultDtoAsync(x => x.Id == id);

            if (car == null)
                return NotFound("Car not found");

            return View(car);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> RentCar(int carId)
        {
            if (carId == null)
            {
                throw new NotFoundException("Car not found");
            }
            if (!(await _unitOfWork.Car.GetFirstOrDefaultDtoAsync(x => x.Id == carId)).Available)
            {
                throw new BadRequestException("Oops something went wrong");
            }

            var userId = int.Parse(User.FindFirst(x => x.Type == ClaimTypes.NameIdentifier).Value);

            await _unitOfWork.Car.RentCarAsync(userId, carId);
            await _unitOfWork.SaveAsync();

            TempData["success"] = "Car successfully rented ";
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Manager")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Manager")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(CarModelDto carDto, IFormFile? file)
        {
            if (!ModelState.IsValid)
            {
                return View(carDto);
            }

            string wwwRootPath = _webHostEnvironment.WebRootPath;
            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(wwwRootPath, @"images\cars");
                var extension = Path.GetExtension(file.FileName);

                using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                {
                    file.CopyTo(fileStreams);
                }
                carDto.ImageUrl = @"\images\cars\" + fileName + extension;
            }
            await _unitOfWork.Car.AddCarAsync(carDto);
            await _unitOfWork.SaveAsync();

            TempData["success"] = "Car successfully added";
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Manager")]
        public async Task<IActionResult> Edit(int id)
        {
            return View(
                await _unitOfWork.Car.GetFirstOrDefaultDtoAsync(x => x.Id == id) ?? throw new NotFoundException("Car not found.")
                );
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Manager")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CarModelDto carDto, IFormFile? file)
        {
            if (!ModelState.IsValid)
            {
                return View(carDto);
            }
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            if (file != null)
            {
                var oldImagePath = Path.Combine(wwwRootPath, carDto.ImageUrl.TrimStart('\\'));
                if (carDto.ImageUrl != null)
                {
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }
                string fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(wwwRootPath, @"images\cars");
                var extension = Path.GetExtension(file.FileName);

                using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                {
                    file.CopyTo(fileStreams);
                }
                carDto.ImageUrl = @"\images\cars\" + fileName + extension;
            }

            await _unitOfWork.Car.UpdateAsync(carDto);
            await _unitOfWork.SaveAsync();

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            await _unitOfWork.Car.DeleteCarAsync(id);
            await _unitOfWork.SaveAsync();

            TempData["success"] = "Car successfully deleted";
            return RedirectToAction("Index");
        }
    }
}