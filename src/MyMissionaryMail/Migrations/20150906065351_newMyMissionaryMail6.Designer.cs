using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Relational.Migrations.Infrastructure;
using MyMissionaryMail.DAL;

namespace MyMissionaryMail.Migrations
{
    [ContextType(typeof(MyMissionaryMailContext))]
    partial class newMyMissionaryMail6
    {
        public override string Id
        {
            get { return "20150906065351_newMyMissionaryMail6"; }
        }
        
        public override string ProductVersion
        {
            get { return "7.0.0-beta5-13549"; }
        }
        
        public override void BuildTargetModel(ModelBuilder builder)
        {
            builder
                .Annotation("SqlServer:ValueGeneration", "Identity");
            
            builder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .GenerateValueOnAdd();
                    
                    b.Property<string>("ConcurrencyStamp")
                        .ConcurrencyToken();
                    
                    b.Property<string>("Name");
                    
                    b.Property<string>("NormalizedName");
                    
                    b.Key("Id");
                    
                    b.Annotation("Relational:TableName", "AspNetRoles");
                });
            
            builder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .GenerateValueOnAdd()
                        .StoreGeneratedPattern(StoreGeneratedPattern.Identity);
                    
                    b.Property<string>("ClaimType");
                    
                    b.Property<string>("ClaimValue");
                    
                    b.Property<string>("RoleId");
                    
                    b.Key("Id");
                    
                    b.Annotation("Relational:TableName", "AspNetRoleClaims");
                });
            
            builder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .GenerateValueOnAdd()
                        .StoreGeneratedPattern(StoreGeneratedPattern.Identity);
                    
                    b.Property<string>("ClaimType");
                    
                    b.Property<string>("ClaimValue");
                    
                    b.Property<string>("UserId");
                    
                    b.Key("Id");
                    
                    b.Annotation("Relational:TableName", "AspNetUserClaims");
                });
            
            builder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .GenerateValueOnAdd();
                    
                    b.Property<string>("ProviderKey")
                        .GenerateValueOnAdd();
                    
                    b.Property<string>("ProviderDisplayName");
                    
                    b.Property<string>("UserId");
                    
                    b.Key("LoginProvider", "ProviderKey");
                    
                    b.Annotation("Relational:TableName", "AspNetUserLogins");
                });
            
            builder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");
                    
                    b.Property<string>("RoleId");
                    
                    b.Key("UserId", "RoleId");
                    
                    b.Annotation("Relational:TableName", "AspNetUserRoles");
                });
            
            builder.Entity("MyMissionaryMail.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .GenerateValueOnAdd();
                    
                    b.Property<int>("AccessFailedCount");
                    
                    b.Property<string>("ConcurrencyStamp")
                        .ConcurrencyToken();
                    
                    b.Property<string>("Email");
                    
                    b.Property<bool>("EmailConfirmed");
                    
                    b.Property<bool>("LockoutEnabled");
                    
                    b.Property<DateTimeOffset?>("LockoutEnd");
                    
                    b.Property<int?>("MissionaryId");
                    
                    b.Property<string>("NormalizedEmail");
                    
                    b.Property<string>("NormalizedUserName");
                    
                    b.Property<string>("PasswordHash");
                    
                    b.Property<string>("PhoneNumber");
                    
                    b.Property<bool>("PhoneNumberConfirmed");
                    
                    b.Property<string>("SecurityStamp");
                    
                    b.Property<bool>("TwoFactorEnabled");
                    
                    b.Property<string>("UserName");
                    
                    b.Key("Id");
                    
                    b.Annotation("Relational:TableName", "AspNetUsers");
                });
            
            builder.Entity("MyMissionaryMail.Models.Email", b =>
                {
                    b.Property<int>("Id")
                        .GenerateValueOnAdd()
                        .StoreGeneratedPattern(StoreGeneratedPattern.Identity);
                    
                    b.Property<int?>("AttachmentCount");
                    
                    b.Property<string>("BodyHtml");
                    
                    b.Property<string>("BodyPlain");
                    
                    b.Property<string>("FromEmail");
                    
                    b.Property<int?>("MissionId");
                    
                    b.Property<int?>("MissionaryId");
                    
                    b.Property<string>("RecipientEmail");
                    
                    b.Property<string>("StrippedHtml");
                    
                    b.Property<string>("StrippedSignature");
                    
                    b.Property<string>("StrippedText");
                    
                    b.Property<string>("Subject");
                    
                    b.Property<DateTime>("TimeStamp");
                    
                    b.Property<long>("TimeStampSeconds");
                    
                    b.Property<string>("UserId");
                    
                    b.Key("Id");
                });
            
            builder.Entity("MyMissionaryMail.Models.Mission", b =>
                {
                    b.Property<int>("Id")
                        .GenerateValueOnAdd()
                        .StoreGeneratedPattern(StoreGeneratedPattern.Identity);
                    
                    b.Property<DateTime>("EndDate");
                    
                    b.Property<string>("MissionName");
                    
                    b.Property<int>("MissionaryId");
                    
                    b.Property<DateTime>("StartDate");
                    
                    b.Key("Id");
                });
            
            builder.Entity("MyMissionaryMail.Models.Missionary", b =>
                {
                    b.Property<int>("Id")
                        .GenerateValueOnAdd()
                        .StoreGeneratedPattern(StoreGeneratedPattern.Identity);
                    
                    b.Property<DateTime>("DateOfBirth");
                    
                    b.Property<string>("Email");
                    
                    b.Property<string>("FirstName");
                    
                    b.Property<string>("LastName");
                    
                    b.Property<string>("Sex");
                    
                    b.Key("Id");
                });
            
            builder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.Reference("Microsoft.AspNet.Identity.EntityFramework.IdentityRole")
                        .InverseCollection()
                        .ForeignKey("RoleId");
                });
            
            builder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.Reference("MyMissionaryMail.Models.ApplicationUser")
                        .InverseCollection()
                        .ForeignKey("UserId");
                });
            
            builder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.Reference("MyMissionaryMail.Models.ApplicationUser")
                        .InverseCollection()
                        .ForeignKey("UserId");
                });
            
            builder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.Reference("Microsoft.AspNet.Identity.EntityFramework.IdentityRole")
                        .InverseCollection()
                        .ForeignKey("RoleId");
                    
                    b.Reference("MyMissionaryMail.Models.ApplicationUser")
                        .InverseCollection()
                        .ForeignKey("UserId");
                });
            
            builder.Entity("MyMissionaryMail.Models.ApplicationUser", b =>
                {
                    b.Reference("MyMissionaryMail.Models.Missionary")
                        .InverseCollection()
                        .ForeignKey("MissionaryId");
                });
            
            builder.Entity("MyMissionaryMail.Models.Email", b =>
                {
                    b.Reference("MyMissionaryMail.Models.Mission")
                        .InverseCollection()
                        .ForeignKey("MissionId");
                });
            
            builder.Entity("MyMissionaryMail.Models.Mission", b =>
                {
                    b.Reference("MyMissionaryMail.Models.Missionary")
                        .InverseCollection()
                        .ForeignKey("MissionaryId");
                });
        }
    }
}
