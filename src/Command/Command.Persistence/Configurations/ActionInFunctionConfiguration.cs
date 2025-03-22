using Command.Domain.Entities.Identity;
using Command.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Command.Persistence.Configurations;

internal sealed class ActionInFunctionConfiguration : IEntityTypeConfiguration<ActionInFunction>
{
    public void Configure(EntityTypeBuilder<ActionInFunction> builder)
    {
        builder.ToTable(TableNames.ActionInFunctions);

        builder.HasKey(x => new { x.ActionId, x.FunctionId });
    }
}
