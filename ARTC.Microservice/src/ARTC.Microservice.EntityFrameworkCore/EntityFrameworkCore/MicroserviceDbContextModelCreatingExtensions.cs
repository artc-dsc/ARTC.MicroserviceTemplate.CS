using ARTC.Microservice.Books;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace ARTC.Microservice.EntityFrameworkCore;

public static class MicroserviceDbContextModelCreatingExtensions
{
    public static void ConfigureMicroservice(
        this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

        builder.Entity<Book>(b =>
        {
            //Configure table & schema name
            b.ToTable(MicroserviceDbProperties.DbTablePrefix + "_Books", MicroserviceDbProperties.DbSchema);

            b.ConfigureByConvention();
        });

        /* Configure all entities here. Example:

        builder.Entity<Question>(b =>
        {
            //Configure table & schema name
            b.ToTable(MicroserviceDbProperties.DbTablePrefix + "Questions", MicroserviceDbProperties.DbSchema);

            b.ConfigureByConvention();

            //Properties
            b.Property(q => q.Title).IsRequired().HasMaxLength(QuestionConsts.MaxTitleLength);

            //Relations
            b.HasMany(question => question.Tags).WithOne().HasForeignKey(qt => qt.QuestionId);

            //Indexes
            b.HasIndex(q => q.CreationTime);
        });
        */
    }
}
