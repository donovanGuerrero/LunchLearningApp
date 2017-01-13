﻿using LunchAndLearn.Data;
using LunchAndLearn.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LunchAndLearn.Data.Interfaces;
using LunchAndLearn.Data.Repositories;
using LunchAndLearn.Management.Interfaces;
using LunchAndLearn.Model.DB_Models;

namespace LunchAndLearn.Management
{
  public class ClassManager : IManagerClass<Class>
  {
    private readonly IClassRepository _classRepository;

    public ClassManager(IClassRepository classRepository)
    {
      _classRepository = classRepository;
    }

    public Class Get(int id)
    {
      using (_classRepository)
      {
        return _classRepository.Get(id);
      }
    }

    public List<Class> GetAll()
    {
      using (_classRepository)
      {
        return _classRepository.GetAll().ToList();
      }
    }

    public int Create(Class entity)
    {
      using (_classRepository)
      {
        _classRepository.Create(entity);
        _classRepository.SaveChanges();
        return entity.ClassId;
      }
    }

    public void Update(Class entity)
    {
      using (_classRepository)
      {
        _classRepository.Update(entity);
        _classRepository.SaveChanges();
      }
    }

    public void Delete(int id)
    {
      using (_classRepository)
      {
        _classRepository.Delete(id);
        _classRepository.SaveChanges(); 
      }
    }

    #region Disposal
    private bool _disposed = false;

    protected virtual void Dispose(bool disposing)
    {
      if (!this._disposed)
      {
        if (disposing)
        {
          //Dispose of all repos used in this class here Example: _productRepository, _personRepository
          _classRepository.Dispose();
        }
      }
      this._disposed = true;
    }

    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }
    #endregion
  }
}
