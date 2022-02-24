using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestTecnicals.Models;
using TestTecnicals.Models.DataSet1TableAdapters;
using static TestTecnicals.Models.DataSet1;

namespace TestTecnicals.Controllers
{
    public class ValuesController : ApiController
    {
        private UsuarioTableAdapter _Usuario = new UsuarioTableAdapter();
        // GET api/values
        public IList<UsuarioRow> Get()
        {
            return _Usuario.GetData().ToList();
        }

        // GET api/values/5
        public UsuarioRow Get(int id)
        {
            var userBY = _Usuario.GetDataBy(id).FirstOrDefault();
            return userBY;
        }

        // POST api/values
        [HttpPost]
        [Route("api/Values/Post")]
        public int Post([FromBody] Usuario value)
        {
            try
            {
                return _Usuario.Insert(value.name, value.pass, value.email, value.id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // PUT api/values/5
        [HttpPost]
        [Route("api/Values/Update")]
        public int Update([FromBody] Usuario value)
        {
            int afect = 0;
            try
            {
                var userExist = Get(value.id);

                if (userExist.id != 0)
                {
                    userExist.name = value.name;
                    userExist.password = value.pass;
                    userExist.email = value.email;
                    afect = _Usuario.Update(userExist);

                }
            }
            catch (Exception)
            {
                throw;
            }
            return afect;
        }

        // DELETE api/values/5
        public int Delete(int id)
        {
            try
            {
                return _Usuario.Delete(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
