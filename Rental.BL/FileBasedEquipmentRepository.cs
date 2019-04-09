using Microsoft.Extensions.Logging;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental.BL
{
    public class FileBasedEquipmentRepository : EquipmentRepositoryBase
    {

        private readonly ILogger<FileBasedEquipmentRepository> _logger;
        private readonly AbstractEquipmentFactory _factory;
        public  FileBasedEquipmentRepository(ILogger<FileBasedEquipmentRepository> logger, AbstractEquipmentFactory factory, string repositoryFilePath) : base()
        {

            if (string.IsNullOrEmpty(repositoryFilePath))
                throw new ArgumentNullException(nameof(repositoryFilePath));

            if (File.Exists(repositoryFilePath) == false)
                throw new FileNotFoundException(nameof(repositoryFilePath));


            _logger = logger;

            _factory = factory;

            _LoadRepository(repositoryFilePath).Wait();
             // Task.Run(() => _LoadRepository(repositoryFilePath));
        }

        private async Task _LoadRepository(string repositoryFilePath)
        {

            
            try {

                string[] equipmentLines = await File.ReadAllLinesAsync(repositoryFilePath);

                if (equipmentLines.Any())
                {

                    Equipments.AddRange(
                        equipmentLines.Select(line =>
                            _factory.CreateEquipment( Enum.Parse<EquipmentType>(line.Split('\t')[2]),

                                new EquipmentOptions
                                {
                                    DateModified = DateTime.Parse(line.Split('\t')[4]),
                                    Id = Guid.Parse(line.Split('\t')[0]),
                                    EquipmentName = line.Split('\t')[1],
                                    IsAvailable = Boolean.Parse(line.Split('\t')[3]),
                                    DateCreated = DateTime.Parse(line.Split('\t')[4])
                                }
                                )
                            )
                            .ToList()
                             ?? new List<Equipment>()
                   );

                }
            }
            catch(Exception ex)
            {
                _logger.LogDebug(ex, nameof(_LoadRepository));
            }
        }
    }
}
