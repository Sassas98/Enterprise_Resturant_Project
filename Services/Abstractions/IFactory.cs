using Applications.Models.Dtos;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.Abstractions {
    public interface IFactory<T, D, R> {

        public T CreateEntity(D dto, int id);

        public R CreateResponse(T? entity);

    }
}
