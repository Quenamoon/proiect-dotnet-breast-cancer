using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands
{
    public class CreatePredictionCommand : IRequest<PredictionData>
    {
        public float Radius { get; set; }
        public float Texture { get; set; }
        public float Perimeter { get; set; }
        public float Area { get; set; }
        public float Smoothness { get; set; }
        public float Compactness { get; set; }
        public float Concavity { get; set; }
        public float ConcavePoints { get; set; }
        public float Symmetry { get; set; }
        public float FractalDimension { get; set; }
    }
}
