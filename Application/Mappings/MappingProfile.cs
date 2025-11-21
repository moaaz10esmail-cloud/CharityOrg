using Application.DTOs;
using Application.DTOs.ReportDTOs;
using Application.Features.Employees.Commands;
using Application.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // RegisterDto -> ApplicationUser
            CreateMap<RegisterDto, ApplicationUser>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email));

            CreateMap<AssignRoleDto, ApplicationRole>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Role));

            // Donation → DonationReportDto
            CreateMap<Donation, DonationReportDto>()
                .ForMember(dest => dest.DonorName, opt => opt.MapFrom(src => src.Donor.FullName));

            // Expense → ExpenseReportDto
            CreateMap<Expense, ExpenseReportDto>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.ExpenseCategory));

            CreateMap<Donation, DonorDonationHistoryDto>()
             .ForMember(dest => dest.BeneficiaryName, opt => opt.MapFrom(src => src.Beneficiary.FullName));

            CreateMap<IGrouping<Guid, Donation>, DonorReportDto>()
               .ForMember(dest => dest.DonorId, opt => opt.MapFrom(src => src.Key))
               .ForMember(dest => dest.DonorName, opt => opt.MapFrom(src => src.First().Donor.FullName))
               .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.First().Donor.Country))
               .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src => src.Sum(x => x.Amount)))
               .ForMember(dest => dest.DonationsCount, opt => opt.MapFrom(src => src.Count()));

            CreateMap<Beneficiary, BeneficiaryReportDto>()
             .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName));

            CreateMap<Donation, BeneficiaryDonationHistoryDto>()
                .ForMember(dest => dest.DonorName, opt => opt.MapFrom(src => src.Donor.FullName));


            CreateMap<Donation, DonationReportModuleDto>()

      .ForMember(dest => dest.DonorName, opt => opt.MapFrom(src => src.Donor.FullName))

      .ForMember(dest => dest.BeneficiaryName, opt => opt.MapFrom(src => src.Beneficiary.FullName))

      .ForMember(dest => dest.DonorCountry, opt => opt.MapFrom(src => src.Donor.Country));

          CreateMap<Volunteer,VolunteerDto>().ReverseMap();

            CreateMap<Project, ProjectDto>().ReverseMap();

            CreateMap<ProjectVolunteer, ProjectVolunteerDto>()
          .ForMember(dest => dest.ProjectName, opt => opt.MapFrom(src => src.Project.Name))
          .ForMember(dest => dest.VolunteerName, opt => opt.MapFrom(src => src.Volunteer.FullName));

            // Mapping for volunteer count per project
            CreateMap<(int ProjectId, string ProjectName, int Count), ProjectVolunteerCountReportDto>()
                .ForMember(dest => dest.ProjectId, opt => opt.MapFrom(src => src.ProjectId))
                .ForMember(dest => dest.ProjectName, opt => opt.MapFrom(src => src.ProjectName))
                .ForMember(dest => dest.VolunteerCount, opt => opt.MapFrom(src => src.Count));

            // Mapping for role distribution
            CreateMap<(string Role, int Count), RoleDistributionReportDto>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role))
                .ForMember(dest => dest.Count, opt => opt.MapFrom(src => src.Count));

            CreateMap<(int ProjectId, string ProjectName, string Status), ProjectStatusReportDto>()
           .ForMember(dest => dest.ProjectId, opt => opt.MapFrom(src => src.ProjectId))
           .ForMember(dest => dest.ProjectName, opt => opt.MapFrom(src => src.ProjectName))
           .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));

            CreateMap<(int ProjectId, string ProjectName, int DurationInDays), ProjectDurationReportDto>()
                .ForMember(dest => dest.ProjectId, opt => opt.MapFrom(src => src.ProjectId))
                .ForMember(dest => dest.ProjectName, opt => opt.MapFrom(src => src.ProjectName))
                .ForMember(dest => dest.DurationInDays, opt => opt.MapFrom(src => src.DurationInDays));

            CreateMap<(int Total, int Ongoing, int Completed), ProjectSummaryReportDto>()
                .ForMember(dest => dest.TotalProjects, opt => opt.MapFrom(src => src.Total))
                .ForMember(dest => dest.OngoingProjects, opt => opt.MapFrom(src => src.Ongoing))
                .ForMember(dest => dest.CompletedProjects, opt => opt.MapFrom(src => src.Completed));

            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<CreateEmployeeCommand, Employee>();

            CreateMap<Notification, NotificationDto>().ReverseMap();
            CreateMap<CreateNotificationDto, Notification>();

        }
    }
}


