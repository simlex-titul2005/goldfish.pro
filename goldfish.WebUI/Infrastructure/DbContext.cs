using SX.WebCore;

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
    }
}