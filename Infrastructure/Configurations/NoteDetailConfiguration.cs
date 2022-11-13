namespace Infrastructure.Configurations;

public class NoteDetailConfiguration : IEntityTypeConfiguration<NoteDetail>
{
    public void Configure(EntityTypeBuilder<NoteDetail> builder)
    {
        builder.ToTable("NoteDetails");
        builder.HasKey(n => n.Id);
        builder.Property(nd => nd.Created).HasColumnType("datetime2").HasPrecision(0).IsRequired();
        builder.Property(nd => nd.LastModified).HasColumnType("datetime2").HasPrecision(0).IsRequired();
    }
}