using Domain.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Base
{
    public class BaseEntity : IBaseEntity, IDisposable
    {   
        public int Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
        public int CreatedBy { get; set; }
        public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.Now;
        public int UpdatedBy { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }

        [NotMapped]
        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {

            }

            _disposed = true;
        }
        public virtual void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
