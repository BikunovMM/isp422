using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Domain.Models;

public partial class DbIsp422Context : DbContext
{
    public DbIsp422Context()
    {
    }

    public DbIsp422Context(DbContextOptions<DbIsp422Context> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server= DESKTOP-K6LFJKO ;Database= db_isp422 ;User Id= Sa ;Password= 12345 ;TrustServerCertificate= True ;");
    }

    public virtual DbSet<View1> View1s { get; set; }

    public virtual DbSet<View4ПорядковыйНомерМинус1> View4ПорядковыйНомерМинус1s { get; set; }

    public virtual DbSet<ДатыВсехКонвертаций> ДатыВсехКонвертацийs { get; set; }

    public virtual DbSet<ИспользованиеФорматов> ИспользованиеФорматовs { get; set; }

    public virtual DbSet<ИсторияКонвертаций> ИсторияКонвертацийs { get; set; }

    public virtual DbSet<Конвертации> Конвертацииs { get; set; }

    public virtual DbSet<НазначениеIdвсемКонвертациям> НазначениеIdвсемКонвертациямs { get; set; }

    public virtual DbSet<Настройки> Настройкиs { get; set; }

    public virtual DbSet<ПараметрКонвертации> ПараметрКонвертацииs { get; set; }

    public virtual DbSet<ПараметрыКонвертации> ПараметрыКонвертацииs { get; set; }

    public virtual DbSet<Пользователи> Пользователиs { get; set; }

    public virtual DbSet<ПорядковыйНомерМинус1> ПорядковыйНомерМинус1s { get; set; }

    public virtual DbSet<Роли> Ролиs { get; set; }

    public virtual DbSet<Файлы> Файлыs { get; set; }

    public virtual DbSet<ФорматыФайлов> ФорматыФайловs { get; set; }

    public virtual DbSet<ЧастотаКонвертаций> ЧастотаКонвертацийs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<View1>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("View_1");

            entity.Property(e => e.Idконвертации).HasColumnName("IDКонвертации");
            entity.Property(e => e.Idпользователя).HasColumnName("IDПользователя");
        });

        modelBuilder.Entity<View4ПорядковыйНомерМинус1>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("View_4_порядковыйНомерМинус1");

            entity.Property(e => e.Idпользователя).HasColumnName("IDПользователя");
        });

        modelBuilder.Entity<ДатыВсехКонвертаций>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ДатыВсехКонвертаций");

            entity.Property(e => e.Idпользователя).HasColumnName("IDПользователя");
        });

        modelBuilder.Entity<ИспользованиеФорматов>(entity =>
        {
            entity.HasKey(e => e.IdиспользованияФорматов).HasName("PK__Использо__9171285F3195ED75");

            entity.ToTable("ИспользованиеФорматов");

            entity.Property(e => e.IdиспользованияФорматов).HasColumnName("IDИспользованияФорматов");
            entity.Property(e => e.Idпользователя).HasColumnName("IDПользователя");
            entity.Property(e => e.Idформата).HasColumnName("IDФормата");

            entity.HasOne(d => d.IdпользователяNavigation).WithMany(p => p.ИспользованиеФорматовs)
                .HasForeignKey(d => d.Idпользователя)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Использов__IDПол__4E88ABD4");

            entity.HasOne(d => d.IdформатаNavigation).WithMany(p => p.ИспользованиеФорматовs)
                .HasForeignKey(d => d.Idформата)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Использов__IDФор__4F7CD00D");
        });

        modelBuilder.Entity<ИсторияКонвертаций>(entity =>
        {
            entity.HasKey(e => e.IdисторииКонвертаций).HasName("PK__ИсторияК__D63642FB00768E2C");

            entity.ToTable("ИсторияКонвертаций");

            entity.Property(e => e.IdисторииКонвертаций).HasColumnName("IDИсторииКонвертаций");
            entity.Property(e => e.Idконвертации).HasColumnName("IDКонвертации");
            entity.Property(e => e.IdпараметровКонвертации).HasColumnName("IDПараметровКонвертации");
            entity.Property(e => e.Idпользователя).HasColumnName("IDПользователя");

            entity.HasOne(d => d.IdконвертацииNavigation).WithMany(p => p.ИсторияКонвертацийs)
                .HasForeignKey(d => d.Idконвертации)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ИсторияКо__IDКон__5070F446");

            entity.HasOne(d => d.IdпользователяNavigation).WithMany(p => p.ИсторияКонвертацийs)
                .HasForeignKey(d => d.Idпользователя)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ИсторияКо__IDПол__5165187F");
        });

        modelBuilder.Entity<Конвертации>(entity =>
        {
            entity.HasKey(e => e.Idконвертации).HasName("PK__Конверта__3ABF9A5D1587A147");

            entity.ToTable("Конвертации");

            entity.Property(e => e.Idконвертации).HasColumnName("IDКонвертации");
            entity.Property(e => e.IdвходногоФайла).HasColumnName("IDВходногоФайла");
            entity.Property(e => e.IdвыходногоФайла).HasColumnName("IDВыходногоФайла");
            entity.Property(e => e.IdпараметровКонвертации).HasColumnName("IDПараметровКонвертации");

            entity.HasOne(d => d.IdвходногоФайлаNavigation).WithMany(p => p.КонвертацииIdвходногоФайлаNavigations)
                .HasForeignKey(d => d.IdвходногоФайла)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Конвертац__IDВхо__52593CB8");

            entity.HasOne(d => d.IdвыходногоФайлаNavigation).WithMany(p => p.КонвертацииIdвыходногоФайлаNavigations)
                .HasForeignKey(d => d.IdвыходногоФайла)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Конвертац__IDВых__5441852A");
        });

        modelBuilder.Entity<НазначениеIdвсемКонвертациям>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("НазначениеIDВсемКонвертациям");

            entity.Property(e => e.Idконвертации).HasColumnName("IDКонвертации");
            entity.Property(e => e.Idпользователя).HasColumnName("IDПользователя");
        });

        modelBuilder.Entity<Настройки>(entity =>
        {
            entity.HasKey(e => e.Idнастроек).HasName("PK__Настройк__11166FF5D815ECC8");

            entity.ToTable("Настройки");

            entity.Property(e => e.Idнастроек).HasColumnName("IDНастроек");
            entity.Property(e => e.Idпользователя).HasColumnName("IDПользователя");
            entity.Property(e => e.Язык)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.IdпользователяNavigation).WithMany(p => p.Настройкиs)
                .HasForeignKey(d => d.Idпользователя)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Настройки__IDПол__5629CD9C");
        });

        modelBuilder.Entity<ПараметрКонвертации>(entity =>
        {
            entity.HasKey(e => e.IdпараметраКонвертации);

            entity.ToTable("ПараметрКонвертации");

            entity.Property(e => e.IdпараметраКонвертации)
                .ValueGeneratedNever()
                .HasColumnName("IDПараметраКонвертации");
            entity.Property(e => e.Название)
                .HasMaxLength(16)
                .IsFixedLength();
        });

        modelBuilder.Entity<ПараметрыКонвертации>(entity =>
        {
            entity.HasKey(e => e.IdпараметраКонвертации);

            entity.ToTable("ПараметрыКонвертации");

            entity.Property(e => e.IdпараметраКонвертации)
                .ValueGeneratedNever()
                .HasColumnName("IDПараметраКонвертации");
            entity.Property(e => e.Значение)
                .HasMaxLength(16)
                .IsFixedLength();
        });

        modelBuilder.Entity<Пользователи>(entity =>
        {
            entity.HasKey(e => e.Idпользователя).HasName("PK__Пользова__B58D26DAE60FCCE0");

            entity.ToTable("Пользователи");

            entity.HasIndex(e => e.Пароль, "UQ__Пользова__130C4ECF13F3C291").IsUnique();

            entity.HasIndex(e => e.Логин, "UQ__Пользова__BC2217D33F4B4A9A").IsUnique();

            entity.Property(e => e.Idпользователя).HasColumnName("IDПользователя");
            entity.Property(e => e.Idроли).HasColumnName("IDРоли");
            entity.Property(e => e.АдресЭлектроннойПочты)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Логин)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Пароль)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.IdролиNavigation).WithMany(p => p.Пользователиs)
                .HasForeignKey(d => d.Idроли)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Пользоват__IDРол__571DF1D5");
        });

        modelBuilder.Entity<ПорядковыйНомерМинус1>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ПорядковыйНомерМинус1");

            entity.Property(e => e.Idпользователя).HasColumnName("IDПользователя");
            entity.Property(e => e.ПорядковыйНомерМинус11).HasColumnName("ПорядковыйНомерМинус1");
        });

        modelBuilder.Entity<Роли>(entity =>
        {
            entity.HasKey(e => e.Idроли).HasName("PK__Роли__22FFC98EB699A054");

            entity.ToTable("Роли");

            entity.HasIndex(e => e.Название, "UQ__Роли__38DA80358CE0501A").IsUnique();

            entity.Property(e => e.Idроли).HasColumnName("IDРоли");
            entity.Property(e => e.Название)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Файлы>(entity =>
        {
            entity.HasKey(e => e.Idфайла).HasName("PK__Файлы__DC2A4F00A787B3C7");

            entity.ToTable("Файлы");

            entity.Property(e => e.Idфайла)
                .ValueGeneratedNever()
                .HasColumnName("IDФайла");
            entity.Property(e => e.Idформата).HasColumnName("IDФормата");
            entity.Property(e => e.НазваниеФайла)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ФорматыФайлов>(entity =>
        {
            entity.HasKey(e => e.Idформата).HasName("PK__ФорматыФ__479E4A84968FED91");

            entity.ToTable("ФорматыФайлов");

            entity.HasIndex(e => e.Название, "UQ__ФорматыФ__38DA8035A12B6CC9").IsUnique();

            entity.Property(e => e.Idформата)
                .ValueGeneratedNever()
                .HasColumnName("IDФормата");
            entity.Property(e => e.Название)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ЧастотаКонвертаций>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ЧастотаКонвертаций");

            entity.Property(e => e.Idпользователя).HasColumnName("IDПользователя");
            entity.Property(e => e.СредняяКонвертация).HasColumnType("decimal(38, 6)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
