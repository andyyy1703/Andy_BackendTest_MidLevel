using backendTest.Context;
using Microsoft.EntityFrameworkCore;

namespace backendTest.Services;

public interface IAcpdService
{
    Task<List<ACPDDto>> GetAcpdData();

    Task<ACPDDto> GetAcpdDataById(string id);

    Task<bool> CreateAcpdData(ACPDDto acpdDto);

    Task<bool> UpdateAcpdData(string id, ACPDDto acpdDto);

    Task<bool> DeleteAcpdData(string id);
}

public class AcpdService : IAcpdService
{
    private readonly BackendTestContext _context;
    public AcpdService(BackendTestContext context)
    {
        _context = context;
    }

    async Task<List<ACPDDto>> IAcpdService.GetAcpdData()
        => await _context.MyOfficeAcpds.Select(x => new ACPDDto
        {
            AcpdSid = x.AcpdSid,
            AcpdCname = x.AcpdCname,
            AcpdEname = x.AcpdEname,
            AcpdSname = x.AcpdSname,
            AcpdEmail = x.AcpdEmail,
            AcpdStatus = x.AcpdStatus,
            AcpdStop = x.AcpdStop,
            AcpdStopMemo = x.AcpdStopMemo,
            AcpdLoginId = x.AcpdLoginId,
            AcpdLoginPwd = x.AcpdLoginPwd,
            AcpdMemo = x.AcpdMemo,
            AcpdNowDateTime = x.AcpdNowDateTime,
            AcpdNowId = x.AcpdNowId,
            AcpdUpdDateTime = x.AcpdUpdDateTime,
            AcpdUpdId = x.AcpdUpdId
        }).ToListAsync();

    async Task<ACPDDto> IAcpdService.GetAcpdDataById(string id)
        => await _context.MyOfficeAcpds
        .Where(x => x.AcpdSid == id)
        .Select(x => new ACPDDto
        {
            AcpdSid = x.AcpdSid,
            AcpdCname = x.AcpdCname,
            AcpdEname = x.AcpdEname,
            AcpdSname = x.AcpdSname,
            AcpdEmail = x.AcpdEmail,
            AcpdStatus = x.AcpdStatus,
            AcpdStop = x.AcpdStop,
            AcpdStopMemo = x.AcpdStopMemo,
            AcpdLoginId = x.AcpdLoginId,
            AcpdLoginPwd = x.AcpdLoginPwd,
            AcpdMemo = x.AcpdMemo,
            AcpdNowDateTime = x.AcpdNowDateTime,
            AcpdNowId = x.AcpdNowId,
            AcpdUpdDateTime = x.AcpdUpdDateTime,
            AcpdUpdId = x.AcpdUpdId
        }).FirstOrDefaultAsync() ?? new ACPDDto();

    async Task<bool> IAcpdService.CreateAcpdData(ACPDDto acpdDto)
    {
        try
        {
            var entity = new ACPDDto
            {
                AcpdSid = acpdDto.AcpdSid,
                AcpdCname = acpdDto.AcpdCname,
                AcpdEname = acpdDto.AcpdEname,
                AcpdSname = acpdDto.AcpdSname,
                AcpdEmail = acpdDto.AcpdEmail,
                AcpdStatus = acpdDto.AcpdStatus,
                AcpdStop = acpdDto.AcpdStop,
                AcpdStopMemo = acpdDto.AcpdStopMemo,
                AcpdLoginId = acpdDto.AcpdLoginId,
                AcpdLoginPwd = acpdDto.AcpdLoginPwd,
                AcpdMemo = acpdDto.AcpdMemo,
                AcpdNowDateTime = DateTime.UtcNow,
                AcpdNowId = "System",
                AcpdUpdDateTime = DateTime.UtcNow,
                AcpdUpdId = "System"
            };
            _context.MyOfficeAcpds.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {
            // Log the exception (not implemented here)
            return false;
        }
    }

    async Task<bool> IAcpdService.UpdateAcpdData(string id, ACPDDto acpdDto)
    {
        try
        {
            var entity = await _context.MyOfficeAcpds.FindAsync(id);
            if (entity == null) return false;
            entity.AcpdCname = acpdDto.AcpdCname;
            entity.AcpdEname = acpdDto.AcpdEname;
            entity.AcpdSname = acpdDto.AcpdSname;
            entity.AcpdEmail = acpdDto.AcpdEmail;
            entity.AcpdStatus = acpdDto.AcpdStatus;
            entity.AcpdStop = acpdDto.AcpdStop;
            entity.AcpdStopMemo = acpdDto.AcpdStopMemo;
            entity.AcpdLoginId = acpdDto.AcpdLoginId;
            entity.AcpdLoginPwd = acpdDto.AcpdLoginPwd;
            entity.AcpdMemo = acpdDto.AcpdMemo;
            entity.AcpdUpdDateTime = DateTime.UtcNow;
            entity.AcpdUpdId = "System";
            _context.MyOfficeAcpds.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {
            // Log the exception (not implemented here)
            return false;
        }
    }

    async Task<bool> IAcpdService.DeleteAcpdData(string id)
    {
        try
        {
            var entity = await _context.MyOfficeAcpds.FindAsync(id);
            if (entity == null) return false;
            _context.MyOfficeAcpds.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {
            // Log the exception (not implemented here)
            return false;
        }
    }
}