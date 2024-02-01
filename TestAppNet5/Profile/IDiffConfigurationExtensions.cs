using DeepDiff.Configuration;
using TestAppNet5.Entities;

namespace TestAppNet5.Profile
{
    public static class IDiffConfigurationExtensions
    {
        public static IEntityConfiguration<TEntity> PersistEntity<TEntity>(this IDeepDiffConfiguration deepDiffConfiguration)
            where TEntity : PersistEntity
        {
            return deepDiffConfiguration.Entity<TEntity>()
                .OnInsert(cfg => cfg.SetValue(x => x.PersistChange, PersistChange.Insert))
                .OnUpdate(cfg => cfg.SetValue(x => x.PersistChange, PersistChange.Update))
                .OnDelete(cfg => cfg.SetValue(x => x.PersistChange, PersistChange.Delete));
        }

        public static IEntityConfiguration<TEntity> PersistEntity<TEntity>(this IEntityConfiguration<TEntity> entityConfiguration)
            where TEntity : PersistEntity
        {
            return entityConfiguration
                .OnInsert(cfg => cfg.SetValue(x => x.PersistChange, PersistChange.Insert))
                .OnUpdate(cfg => cfg.SetValue(x => x.PersistChange, PersistChange.Update))
                .OnDelete(cfg => cfg.SetValue(x => x.PersistChange, PersistChange.Delete));
        }
    }
}