using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mobile.al.Data;
using mobile.al.Interfaces;
using mobile.al.Models;
using mobile.al.ViewModels;
using System.Net;

namespace mobile.al.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarRepository _carRepository;
        private readonly IPhotoService _photoService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CarController(ICarRepository carRepository, IPhotoService photoService, IHttpContextAccessor httpContextAccessor)
        {
            _carRepository = carRepository;
            _photoService = photoService;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Car> cars = await _carRepository.GetAll();
            return View(cars);
        }


        public async Task<IActionResult> Detail(int id)
        {
            Car car = await _carRepository.GetByIdAsync(id);
            return View(car);
        }

        public IActionResult Create()
        {
            var curUserId = _httpContextAccessor.HttpContext?.User.GetUserId();
            var createCarViewModel = new CreateCarViewModel { AppUserId = curUserId };
            return View(createCarViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCarViewModel carVM)
        {
            if(ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoAsync(carVM.Image);

                var car = new Car
                {
                    CarCategory = carVM.CarCategory,
                    Title = carVM.Title,
                    Description = carVM.Description,
                    Price = carVM.Price,
                    Mileage = carVM.Mileage,
                    Image = result.Url.ToString(),
                    FuelTypeCategory = carVM.FuelTypeCategory,
                    GearBoxCategory = carVM.GearBoxCategory,
                    //DateProduced = carVM.DateProduced,
                    Accidented = carVM.Accidented,
                    Model = carVM.Model,
                    HorsePower = carVM.HorsePower,
                    Color = carVM.Color,
                    Extras = carVM.Extras,
                    AppUserId = carVM.AppUserId,
                    Address = new Address
                    {
                        Street = carVM.Address.Street,
                        City = carVM.Address.City,
                        State = carVM.Address.State
                    }
                };
                _carRepository.Add(car);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Photo upload failed");
            }

            return View(carVM);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var car = await _carRepository.GetByIdAsync(id);
            if (car == null) return View("Error");
            var carVM = new EditCarViewModel
            {
                CarCategory = car.CarCategory,
                Title = car.Title,
                Description = car.Description,
                Price = car.Price,
                Mileage = car.Mileage,
                URL = car.Image,
                //DateAdded = car.DateAdded,
                FuelTypeCategory = car.FuelTypeCategory,
                GearBoxCategory = car.GearBoxCategory,
                //DateProduced = car.DateProduced,
                Accidented = car.Accidented,
                Model = car.Model,
                HorsePower = car.HorsePower,
                Color = car.Color,
                Extras = car.Extras,
            };
            return View(carVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditCarViewModel carVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit car");
                return View("Edit", carVM);
            }

            var userCar = await _carRepository.GetByIdAsyncNoTracking(id);

            if (userCar != null)
            {
                try
                {
                    await _photoService.DeletePhotoAsync(userCar.Image);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Could not delete photo");
                    return View(carVM);
                }
                var photoResult = await _photoService.AddPhotoAsync(carVM.Image);

                var car = new Car
                {
                    CarCategory = carVM.CarCategory,
                    Title = carVM.Title,
                    Description = carVM.Description,
                    Price = carVM.Price,
                    Mileage = carVM.Mileage,
                    Image = photoResult.Url.ToString(),
                    //DateAdded = carVM.DateAdded,
                    FuelTypeCategory = carVM.FuelTypeCategory,
                    GearBoxCategory = carVM.GearBoxCategory,
                    //DateProduced = carVM.DateProduced,
                    Accidented = carVM.Accidented,
                    Model = carVM.Model,
                    HorsePower = carVM.HorsePower,
                    Color = carVM.Color,
                    Extras = carVM.Extras,
                    AddressId = carVM.AddressId,
                    Address = carVM.Address,
                };

                _carRepository.Update(car);

                return RedirectToAction("Index");
            }
            else
            {
                return View(carVM);
            }
        }


        public async Task<IActionResult> Delete(int id)
        {
            var carDetails = await _carRepository.GetByIdAsync(id);
            if (carDetails == null) return View("Error");
            return View(carDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            var carDetails = await _carRepository.GetByIdAsync(id);
            if (carDetails == null) return View("Error");

            _carRepository.Delete(carDetails);
            return RedirectToAction("Index");
        }

    }
}
