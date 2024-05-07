using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_BE_1.ModelFromSQL;
using System;
using System.Linq;


namespace Web_BE_1.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class TblHanghoaController : ControllerBase
	{
        private readonly DBContextBanhang _dbContext;
        public TblHanghoaController(DBContextBanhang dbContext)
		{
            _dbContext = dbContext;
        }

		[HttpGet]
		[Route("/TblHanghoa/Get")]
		public IActionResult GetList()
		{
            var hangHoas = _dbContext.TblHanghoa1s.ToList();
            return Ok(new { data = hangHoas });
        }

		[HttpPost]
		[Route("/TblHanghoa/Insert")]
		public IActionResult Insert(string idnhom,string ma, string ten, decimal gianhap, decimal giaban)
		{
			TblHanghoa hh = new TblHanghoa();
			hh.HhId = Guid.NewGuid(); //tự sinh khóa
			hh.HhNhhId = new Guid(idnhom); 
			hh.HhMa = ma;
			hh.HhTen = ten;
			hh.HhGianhap = gianhap;
			hh.HhGiaban = giaban;

            _dbContext.TblHanghoa1s.Add(hh);
            _dbContext.SaveChanges();

            return Ok(new {hh});
		}

		[HttpPost]
		[Route("/TblHanghoa/Update")]
		public IActionResult Update(Guid hhId,string idnhom,string ma, string ten, decimal gianhap, decimal giaban)
		{
            var hh = _dbContext.TblHanghoa1s.Find(hhId);
            if (hh == null)
            {
                return NotFound();
            }
            //cập nhật các thông tin của hàng hóa
            hh.HhNhhId = new Guid(idnhom);
            hh.HhMa = ma;
			hh.HhTen = ten;
			hh.HhGianhap = gianhap;
			hh.HhGiaban = giaban;

            _dbContext.TblHanghoa1s.Update(hh);
            _dbContext.SaveChanges();
            return Ok(new {hh});
		}

		[HttpDelete]
		[Route("/TblHanghoa/Delete")]
		public IActionResult Delete(Guid hhId, Guid idnhom)
		{
            var hh = _dbContext.TblHanghoa1s.Find(hhId);
            if (hh == null)
            {
                return NotFound();
            }

            var hangHoasToDelete = _dbContext.TblHanghoa1s.Where(h => h.HhId == hhId && h.HhNhhId == idnhom).ToList();
            _dbContext.TblHanghoa1s.RemoveRange(hangHoasToDelete);
            _dbContext.SaveChanges();

			return Ok(new { hhId,idnhom });
		}



	}


}
