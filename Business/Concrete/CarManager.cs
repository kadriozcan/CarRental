﻿using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal; 
        }

        [CacheAspect]
        [PerformanceAspect(4)]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.Listed);
        }

        [CacheAspect]
        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id), Messages.Listed);
        }


        //[ValidationAspect(typeof(CarValidator))]
        //[SecuredOperation("car.add")]
        //[CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            ValidationTool.Validate(new CarValidator(), car);


            _carDal.Add(car);
            return new SuccessResult(Messages.Added);
        }



        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId), Messages.Listed);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId), Messages.Listed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailDtos(), Messages.Listed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandId(int brandId)
        {
            var result = _carDal.GetCarDetailDtos(c => c.BrandId == brandId);
            if (result.Count==0)
            {
                return new ErrorDataResult<List<CarDetailDto>>(default, Messages.CarNotFound);
            }
            return new SuccessDataResult<List<CarDetailDto>>(result, Messages.Listed);
        
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByColorId(int colorId)
        {
            var result = _carDal.GetCarDetailDtos(c => c.ColorId == colorId);
            if (result.Count==0)
            {
                return new ErrorDataResult<List<CarDetailDto>>(default, Messages.CarNotFound);

            }
            return new SuccessDataResult<List<CarDetailDto>>(result, Messages.Listed);

        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandIdColorId(int brandId, int colorId)
        {
            var result = _carDal.GetCarDetailDtos(c => c.BrandId == brandId && c.ColorId == colorId);
            if (result.Count == 0)
            {
                return new ErrorDataResult<List<CarDetailDto>>(default, Messages.CarNotFound);

            }
            return new SuccessDataResult<List<CarDetailDto>>(result, Messages.Listed);
        }

    }
}
