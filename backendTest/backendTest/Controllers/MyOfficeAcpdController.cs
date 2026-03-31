using backendTest.Context;
using backendTest.Services;
using Microsoft.AspNetCore.Mvc;

namespace backendTest.Controllers;

[ApiController]
[Route("api/myofficeacpd")]
public class MyOfficeAcpdController : ControllerBase
{
    private readonly BackendTestContext _context;
    private readonly IAcpdService _acpdService;

    public MyOfficeAcpdController(
        BackendTestContext context,
        IAcpdService acpdService)
    {
        _context = context;
        _acpdService = acpdService;
    }
    /// <summary>
    /// 讀取 全ACPD 資料
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetAcpdData()
    {
        var data = await _acpdService.GetAcpdData();
        return Ok(data);
    }

    /// <summary>
    /// 讀取 單一ACPD 資料
    /// </summary>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAcpdDataById([FromRoute] string id)
    {
        var data = await _acpdService.GetAcpdDataById(id);
        return data == null ? NotFound() : Ok(data);
    }

    /// <summary>
    /// 新增 ACPD 資料
    /// </summary>
    /// <remarks>
    /// 測試用 JSON：
    /// 
    ///     POST /api/myofficeacpd
    ///     {
    ///        "acpdSid": "USER20260331001",
    ///        "acpdCname": "王小明",
    ///        "acpdEname": "Kevin Wang",
    ///        "acpdEmail": "kevin@example.com",
    ///        "acpdStatus": 1,
    ///        "acpdStop": false
    ///     }
    /// </remarks>
    [HttpPost]
    public async Task<IActionResult> CreateAcpdData([FromBody] ACPDDto acpdDto)
        => await _acpdService.CreateAcpdData(acpdDto) ? Ok() : BadRequest();

    /// <summary>
    /// 修改 ACPD 資料
    /// </summary>
    /// <remarks>
    /// 測試用 JSON：
    /// 
    ///     POST /api/myofficeacpd
    ///     {
    ///        "acpdSid": "USER20260331001",
    ///        "acpdCname": "王小明",
    ///        "acpdEname": "Kevin Wang",
    ///        "acpdEmail": "kevin@example.com",
    ///        "acpdStatus": 1,
    ///        "acpdStop": false
    ///     }
    /// </remarks>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAcpdData([FromRoute] string id, ACPDDto acpdDto)
        => await _acpdService.UpdateAcpdData(id, acpdDto) ? Ok() : BadRequest();

    /// <summary>
    /// 刪除 單一ACPD 資料
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAcpdData([FromRoute] string id)
        => await _acpdService.DeleteAcpdData(id) ? Ok() : BadRequest();
}
