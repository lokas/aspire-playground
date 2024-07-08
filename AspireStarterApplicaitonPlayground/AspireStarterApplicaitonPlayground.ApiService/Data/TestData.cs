using Microsoft.EntityFrameworkCore;

namespace AspireStarterApplicaitonPlayground.ApiService.Data;

public class TestData(DbContextOptions options) : DbContext(options);