using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examen.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Examen.Infrastructure.Configurations
{
    public class BilanConfiguration : IEntityTypeConfiguration<Bilan>

    {
        public void Configure(EntityTypeBuilder<Bilan> builder)
        {
            builder.HasKey(B => new
            {
                B.CodePatient,
                B.CodeInfirmier,
                B.DatePrelevement            });
            builder.HasOne(P => P.Infirmier).WithMany(P => P.Bilans).HasForeignKey(P => P.CodeInfirmier);
            builder.HasOne(P => P.Patient).WithMany(P => P.Bilans).HasForeignKey(P => P.CodePatient);

        }
    }
}
