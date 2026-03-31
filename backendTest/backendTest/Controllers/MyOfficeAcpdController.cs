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
    /// <remarks>
    /// 測試用 JSON：
    ///{
    ///  "acpdSid": "USER20260331001",
    ///}
    /// </remarks>
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
    ///{
    ///  "acpdSid": "USER20260331001",
    ///  "acpdCname": "王小明",
    ///  "acpdEname": "Kevin Wang",
    ///  "acpdSname": "小明",
    ///  "acpdEmail": "kevin.wang@example.com",
    ///  "acpdStatus": 1,
    ///  "acpdStop": false,
    ///  "acpdStopMemo": null,
    ///  "acpdLoginId": "kevin_001",
    ///  "acpdLoginPwd": "Password123!",
    ///  "acpdMemo": "這是後端測試用範例帳號",
    ///  "acpdNowDateTime": "2026-03-31T15:00:00",
    ///  "acpdNowId": "ADMIN_01",
    ///  "acpdUpdDateTime": "2026-03-31T15:30:00",
    ///  "acpdUpdId": "ADMIN_01"
    ///}
    /// </remarks>
    [HttpPost]
    public async Task<IActionResult> CreateAcpdData([FromBody] ACPDDto acpdDto)
        => await _acpdService.CreateAcpdData(acpdDto) ? Ok() : BadRequest();

    /// <summary>
    /// 修改 ACPD 資料
    /// </summary>
    /// <remarks>
    /// 測試用 JSON：
    ///{
    ///  "acpdSid": "需要修改的Id",
    ///  --------------------------
    ///  以下為修改內容
    ///  "acpdCname": "王小明",
    ///  "acpdEname": "Kevin Wang",
    ///  "acpdSname": "小明",
    ///  "acpdEmail": "kevin.wang@example.com",
    ///  "acpdStatus": 1,
    ///  "acpdStop": false,
    ///  "acpdStopMemo": null,
    ///  "acpdLoginId": "kevin_001",
    ///  "acpdLoginPwd": "Password123!",
    ///  "acpdMemo": "這是後端測試用範例帳號",
    ///  "acpdNowDateTime": "2026-03-31T15:00:00",
    ///  "acpdNowId": "ADMIN_01",
    ///  "acpdUpdDateTime": "2026-03-31T15:30:00",
    ///  "acpdUpdId": "ADMIN_01"
    ///}
    /// </remarks>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAcpdData([FromRoute] string id, ACPDDto acpdDto)
        => await _acpdService.UpdateAcpdData(id, acpdDto) ? Ok() : BadRequest();

    /// <summary>
    /// 刪除 單一ACPD 資料
    /// </summary>
    /// <remarks>
    /// 測試用 JSON：
    ///{
    ///  "acpdSid": "需要刪除的Id",
    ///}
    /// </remarks>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAcpdData([FromRoute] string id)
        => await _acpdService.DeleteAcpdData(id) ? Ok() : BadRequest();
}
