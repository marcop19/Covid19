using Microsoft.EntityFrameworkCore;

namespace covid19
{
  public class LibraryContext : DbContext
  {
    public DbSet<datiprovince> dati_provincia { get; set; }
    public DbSet<datiregioni> dati_regione { get; set; }
    public DbSet<datinazione> dati_nazione { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseMySQL("server=raspberrypi;database=info_covid19;user=sa;password=raynor3");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<datiprovince>(entity =>
      {
        entity.HasKey(e => e.id);
        entity.Property(e => e.data).IsRequired();
        entity.Property(e => e.stato);
        entity.Property(e => e.codice_regione);
        entity.Property(e => e.denominazione_regione);
        entity.Property(e => e.codice_provincia);
        entity.Property(e => e.denominazione_provincia);
        entity.Property(e => e.sigla_provincia);
        entity.Property(e => e.lat);
        entity.Property(e => e.@long);
        entity.Property(e => e.totale_casi);
        entity.Property(e => e.note);
      });
   
      modelBuilder.Entity<datiregioni>(entity =>
      {
        entity.HasKey(e => e.id);
        entity.Property(e => e.data).IsRequired();
        entity.Property(e => e.stato);
        entity.Property(e => e.codice_regione);
        entity.Property(e => e.denominazione_regione);
        entity.Property(e => e.lat);
        entity.Property(e => e.@long);
        entity.Property(e => e.ricoverati_con_sintomi);
        entity.Property(e => e.terapia_intensiva);
        entity.Property(e => e.totale_ospedalizzati);
        entity.Property(e => e.isolamento_domiciliare);
        entity.Property(e => e.totale_positivi);
        entity.Property(e => e.variazione_totale_positivi);
        entity.Property(e => e.nuovi_positivi);
        entity.Property(e => e.dimessi_guariti);
        entity.Property(e => e.deceduti);
        entity.Property(e => e.casi_da_sospetto_diagnostico);
        entity.Property(e => e.casi_da_screening);
        entity.Property(e => e.totale_casi);
        entity.Property(e => e.tamponi);
        entity.Property(e => e.casi_testati);
        entity.Property(e => e.note);
      });

      modelBuilder.Entity<datinazione>(entity =>
      {
        entity.HasKey(e => e.id);
        entity.Property(e => e.data).IsRequired();
        entity.Property(e => e.stato);
        entity.Property(e => e.ricoverati_con_sintomi);
        entity.Property(e => e.terapia_intensiva);
        entity.Property(e => e.totale_ospedalizzati);
        entity.Property(e => e.isolamento_domiciliare);
        entity.Property(e => e.totale_positivi);
        entity.Property(e => e.variazione_totale_positivi);
        entity.Property(e => e.nuovi_positivi);
        entity.Property(e => e.dimessi_guariti);
        entity.Property(e => e.deceduti);
        entity.Property(e => e.casi_da_sospetto_diagnostico);
        entity.Property(e => e.casi_da_screening);
        entity.Property(e => e.totale_casi);
        entity.Property(e => e.tamponi);
        entity.Property(e => e.casi_testati);
        entity.Property(e => e.note);
      });
    }
  }
}