using goldfish.WebUI.Models;
using SX.WebCore;
using System.Data.Entity;

namespace goldfish.WebUI.Infrastructure
{
    /// <summary>
    /// Контекст подключения к БД (EF)
    /// </summary>
    public sealed class DbContext : SxDbContext
    {
        /// <summary>
        /// Задаем строку подключения.
        /// В последствии можно убрать, т.к. для одного проекта всегда используется только одна строка подключения
        /// </summary>
        public DbContext() : base("DbContext") { }

        /// <summary>
        /// Сервисы сайта
        /// </summary>
        public new DbSet<SiteService> SiteServices { get; set; }
    }
}