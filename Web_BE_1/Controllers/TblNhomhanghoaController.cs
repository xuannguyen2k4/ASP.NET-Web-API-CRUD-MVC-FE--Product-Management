using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_BE_1.ModelFromSQL;

namespace Web_BE_1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TblNhomhanghoaController : ControllerBase
    {
        private readonly DBContextBanhang _dbContext;
        public TblNhomhanghoaController(DBContextBanhang dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("/TblNhomhanghoa/Get")]
        public IActionResult GetList()
        {
            return Ok(new { data = _dbContext.TblNhomhanghoa1s.ToList() });
        }

        [HttpPost]
        [Route("/TblNhomhanghoa/Insert")]
        public IActionResult Insert(string ma, string ten)
        {
            TblNhomhanghoa nhh = new TblNhomhanghoa();
            nhh.NhhId = Guid.NewGuid(); //tự sinh khóa
            nhh.NhhMa = ma;
            nhh.NhhTen = ten;

            _dbContext.TblNhomhanghoa1s.Add(nhh);
            _dbContext.SaveChanges();

            return Ok(new { nhh });
        }

        [HttpPost]
        [Route("/TblNhomhanghoa/Update")]
        public IActionResult Update(Guid nhhId, string ma, string ten)
        {
            var nhh = _dbContext.TblNhomhanghoa1s.Find(nhhId);
            if (nhh == null)
            {
                return NotFound();
            }
            nhh.NhhMa = ma;
            nhh.NhhTen = ten;

            _dbContext.TblNhomhanghoa1s.Update(nhh);
            _dbContext.SaveChanges();

            return Ok(new { nhh });
        }

        [HttpDelete]
        [Route("/TblNhomhanghoa/Delete")]
        public IActionResult Delete(Guid nhhId)
        {
            var nhh = _dbContext.TblNhomhanghoa1s.Find(nhhId);
            if (nhh == null)
            {
                return NotFound();
            }

            var nhomHangHoasToDelete = _dbContext.TblNhomhanghoa1s.Where(h => h.NhhId == nhhId).ToList();
            _dbContext.TblNhomhanghoa1s.RemoveRange(nhomHangHoasToDelete);
            _dbContext.SaveChanges();

            return Ok(new { nhhId});
        }

    }
}
