// <auto-generated />
using System;
using DocumentLabel.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DocumentLabel.Infrastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DocumentLabel.Domain.DocumentRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<string>("DocumentCreationDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DocumentDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DocumentName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DocumentNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DocumentTypeId")
                        .HasColumnType("int");

                    b.Property<string>("DocumentVesrion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("ModifiedBy")
                        .HasColumnType("int");

                    b.Property<string>("OrganizationUnitCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DocumentTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("DocumentRequests");
                });

            modelBuilder.Entity("DocumentLabel.Domain.DocumentRequestFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DocumentRequestId")
                        .HasColumnType("int");

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DocumentRequestId");

                    b.ToTable("DocumentRequestFile");
                });

            modelBuilder.Entity("DocumentLabel.Domain.DocumentRequestTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DocumentRequestId")
                        .HasColumnType("int");

                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DocumentRequestId");

                    b.HasIndex("TagId");

                    b.ToTable("DocumentRequestTag");
                });

            modelBuilder.Entity("DocumentLabel.Domain.Shared.Lookup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Lookup");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = 1
                        },
                        new
                        {
                            Id = 2,
                            Type = 1
                        },
                        new
                        {
                            Id = 3,
                            Type = 2
                        },
                        new
                        {
                            Id = 4,
                            Type = 2
                        });
                });

            modelBuilder.Entity("DocumentLabel.Domain.Shared.LookupLocale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Language")
                        .HasColumnType("int");

                    b.Property<int>("LookupId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LookupId");

                    b.ToTable("LookupLocale");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Language = 2,
                            LookupId = 1,
                            Text = "Public"
                        },
                        new
                        {
                            Id = 2,
                            Language = 2,
                            LookupId = 2,
                            Text = "Confidential"
                        },
                        new
                        {
                            Id = 3,
                            Language = 2,
                            LookupId = 3,
                            Text = "IAM"
                        },
                        new
                        {
                            Id = 4,
                            Language = 2,
                            LookupId = 4,
                            Text = "POL"
                        });
                });

            modelBuilder.Entity("DocumentLabel.Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DocumentLabel.Domain.DocumentRequest", b =>
                {
                    b.HasOne("DocumentLabel.Domain.Shared.Lookup", "DocumentType")
                        .WithMany()
                        .HasForeignKey("DocumentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DocumentLabel.Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DocumentType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DocumentLabel.Domain.DocumentRequestFile", b =>
                {
                    b.HasOne("DocumentLabel.Domain.DocumentRequest", null)
                        .WithMany("Files")
                        .HasForeignKey("DocumentRequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DocumentLabel.Domain.DocumentRequestTag", b =>
                {
                    b.HasOne("DocumentLabel.Domain.DocumentRequest", "DocumentRequest")
                        .WithMany("DocumentRequestTags")
                        .HasForeignKey("DocumentRequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DocumentLabel.Domain.Shared.Lookup", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("DocumentRequest");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("DocumentLabel.Domain.Shared.LookupLocale", b =>
                {
                    b.HasOne("DocumentLabel.Domain.Shared.Lookup", "Lookup")
                        .WithMany("Locales")
                        .HasForeignKey("LookupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lookup");
                });

            modelBuilder.Entity("DocumentLabel.Domain.DocumentRequest", b =>
                {
                    b.Navigation("DocumentRequestTags");

                    b.Navigation("Files");
                });

            modelBuilder.Entity("DocumentLabel.Domain.Shared.Lookup", b =>
                {
                    b.Navigation("Locales");
                });
#pragma warning restore 612, 618
        }
    }
}
