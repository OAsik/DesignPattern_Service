using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XaPa.Service.Data.Infrastructure.DataContext;
using XaPa.Service.Data.UnitOfWork.Infrastructure;
using XaPa.Service.Data.UnitOfWork.XaPa;

namespace XaPa.Service.Manager.BusinessManager
{
    public abstract class BaseManager
    {
        private IUnitOfWork _iUow;

        //private readonly XaPaDataContext _context;

        public IUnitOfWork IUOW
        {
            get
            {
                if (_iUow == null)
                {
                    _iUow = new XaPaUnitOfWork(new XaPaDataContext());
                }

                return _iUow;
            }
        }
    }
}