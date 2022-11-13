namespace Infrastructure.Configurations;

public class NoteConfiguration : IEntityTypeConfiguration<Note>
{
    public void Configure(EntityTypeBuilder<Note> builder)
    {
        builder.ToTable("Notes");
        builder.HasKey(n => n.Id);
        builder.Property(n => n.Title).HasMaxLength(100).IsRequired();
        builder.Property(n => n.Content).HasMaxLength(2000);

        builder.HasOne(n => n.Detail).WithOne(nd => nd.Note).HasForeignKey<NoteDetail>(nd => nd.NoteId);
        builder.HasOne(n => n.Category).WithMany(c => c.Notes).HasForeignKey(n => n.CategoryId);
    }
}
