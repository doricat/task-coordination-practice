using Coordinator.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Coordinator.Web.Data;

public class PgSqlDbContext : DbContext
{
    private static readonly JsonSerializerOptions SerializerOptions = new(JsonSerializerDefaults.Web);

#pragma warning disable CS8618
    public PgSqlDbContext(DbContextOptions<PgSqlDbContext> options) : base(options)
#pragma warning restore CS8618
    {
    }

    public DbSet<Step> Steps { get; set; }

    public DbSet<StepInstance> StepInstances { get; set; }

    public DbSet<FlowTemplate> FlowTemplates { get; set; }

    public DbSet<FlowInstance> FlowInstances { get; set; }

    public DbSet<Worker> Workers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Step>(builder =>
        {
            builder.ToTable("steps");

            builder.HasKey(x => x.Id).HasName("pk_steps");
            builder.HasIndex(x => new {x.Id, x.Index}).IsUnique().HasDatabaseName("ix_steps_id_index");

            builder.Property(x => x.Id).HasColumnName("id").HasColumnType("bigint").ValueGeneratedNever();
            builder.Property(x => x.WorkerId).HasColumnName("worker_id").HasColumnType("bigint").IsRequired();
            builder.Property(x => x.Index).HasColumnName("index").HasColumnType("int").IsRequired();
            builder.Property(x => x.Name).HasColumnName("name").HasColumnType("varchar").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Timeout).HasColumnName("timeout").HasColumnType("int");
            builder.Property(x => x.MaxRetries).HasColumnName("max_retries").HasColumnType("int");
            builder.Property(x => x.Flag).HasColumnName("flag").HasColumnType("int").IsRequired();

            builder.HasOne(x => x.Worker).WithMany(x => x.Steps).HasForeignKey(x => x.WorkerId).IsRequired().OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<StepInstance>(builder =>
        {
            builder.ToTable("step_instances");

            builder.HasKey(x => x.Id).HasName("pk_step_instances");

            builder.Property(x => x.Id).HasColumnName("id").HasColumnType("bigint").ValueGeneratedNever();
            builder.Property(x => x.StepId).HasColumnName("step_id").HasColumnType("bigint").IsRequired();
            builder.Property(x => x.Input).HasColumnName("input").HasColumnType("jsonb")
                .HasConversion(x => JsonSerializer.Serialize(x, SerializerOptions),
                    x => JsonSerializer.Deserialize<IDictionary<string, object>>(x, SerializerOptions));
            builder.Property(x => x.Output).HasColumnName("output").HasColumnType("jsonb")
                .HasConversion(x => JsonSerializer.Serialize(x, SerializerOptions),
                    x => JsonSerializer.Deserialize<IDictionary<string, object>>(x, SerializerOptions));

            builder.HasOne(x => x.Step).WithMany(x => x.Instances).HasForeignKey(x => x.StepId).IsRequired().OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<FlowTemplate>(builder =>
        {
            builder.ToTable("flow_templates");

            builder.HasKey(x => x.Id).HasName("pk_flow_templates");

            builder.Property(x => x.Id).HasColumnName("id").HasColumnType("bigint").ValueGeneratedNever();
            builder.Property(x => x.Name).HasColumnName("name").HasColumnType("varchar").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Arcs).HasColumnName("arcs").HasColumnType("jsonb").IsRequired()
                .HasConversion(x => JsonSerializer.Serialize(x, SerializerOptions),
                    x => JsonSerializer.Deserialize<bool[][]>(x, SerializerOptions));
        });

        modelBuilder.Entity<FlowInstance>(builder =>
        {
            builder.ToTable("flow_instances");

            builder.HasKey(x => x.Id).HasName("pk_flow_instances");

            builder.Property(x => x.Id).HasColumnName("id").HasColumnType("bigint").ValueGeneratedNever();
            builder.Property(x => x.TemplateId).HasColumnName("template_id").HasColumnType("bigint").IsRequired();
            builder.Property(x => x.CurrentStepInstanceId).HasColumnName("current_step_instance_id").HasColumnType("bigint").IsRequired();
            builder.Property(x => x.State).HasColumnName("state").HasColumnType("int").IsRequired();
            builder.Property(x => x.CreatedAt).HasColumnName("created_at").HasColumnType("timestamp").IsRequired();
            builder.Property(x => x.UpdatedAt).HasColumnName("updated_at").HasColumnType("timestamp");

            builder.HasOne(x => x.Template).WithMany(x => x.Instances).HasForeignKey(x => x.TemplateId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            // builder.HasOne(x => x.CurrentStep).WithMany(x => x.FlowInstances).HasForeignKey(x => x.CurrentStepInstanceId).IsRequired().OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Worker>(builder =>
        {
            builder.ToTable("workers");

            builder.HasKey(x => x.Id).HasName("pk_workers");

            builder.Property(x => x.Id).HasColumnName("id").HasColumnType("bigint").ValueGeneratedNever();
            builder.Property(x => x.Name).HasColumnName("name").HasColumnType("varchar").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Type).HasColumnName("type").HasColumnType("int").IsRequired();
        });

        modelBuilder.Entity<StepInTemplate>(builder =>
        {
            builder.ToTable("steps_in_templates");

            builder.HasKey(x => new {x.TemplateId, x.StepId}).HasName("pk_steps_in_templates");

            builder.Property(x => x.TemplateId).HasColumnName("template_id").HasColumnType("bigint").ValueGeneratedNever();
            builder.Property(x => x.StepId).HasColumnName("step_id").HasColumnType("bigint").ValueGeneratedNever();

            builder.HasOne(x => x.Template).WithMany(x => x.Steps).HasForeignKey(x => x.TemplateId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Step).WithMany(x => x.Templates).HasForeignKey(x => x.StepId).IsRequired().OnDelete(DeleteBehavior.Cascade);
        });
    }
}