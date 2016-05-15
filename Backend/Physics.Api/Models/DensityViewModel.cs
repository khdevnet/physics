using Physics.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Physics.Api.Models
{
    public class DensityViewModel
    {
        public DensityViewModel()
        {

        }
        public DensityViewModel(Density density)
        {
            this.Id = density.Id;
            this.Title = density.Title;
            this.Value = density.Value;
        }
        public string Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [Range(0, float.MaxValue)]
        public float Value { get; set; }
    }

    public static class DensityViewModelExtension
    {
        public static Task<DensityViewModel> ToViewModelAync(this Task<Density> density)
        {
            return Task.Run(() => density.Result.ToViewModel());
        }
        public static DensityViewModel ToViewModel(this Density density)
        {
            return new DensityViewModel(density);
        }

        public static Density ToDomainModel(this DensityViewModel densityViewModel)
        {
            var density = new Density();
            density.Id = densityViewModel.Id;
            density.Title = densityViewModel.Title;
            density.Value = densityViewModel.Value;
            return density;
        }
    }
}