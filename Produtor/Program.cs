using Confluent.Kafka;
using Confluent.SchemaRegistry;
using Confluent.SchemaRegistry.Serdes;
using Produtor.dev.by;

var schemaConfig = new SchemaRegistryConfig
{
  Url = "http://localhost:8081",BasicAuthUserInfo=""
};

var SchemaRegistry = new CachedSchemaRegistryClient(schemaConfig);

var config = new ProducerConfig{ BootstrapServers = "localhost:9092" };

using var producer = new ProducerBuilder<string, dev.by.Curso>(config)
.SetValueSerializer(new AvroSerializer<dev.by.Curso>(SchemaRegistry))
.Build();

 GeradorDeCursos gerador = new GeradorDeCursos();
 string NomeCursoAleatorio = gerador.GerarNomeCurso();

var message = new Message<string, dev.by.Curso>
{
    Key = Guid.NewGuid().ToString(),
    Value = new dev.by.Curso
    {
        id = Guid.NewGuid().ToString(),
        descricao = NomeCursoAleatorio
    }
};

var result = await producer.ProduceAsync("cursos", message);

Console.WriteLine($"Tópico: {result.Topic}, Partição {result.Partition} e Offset {result.Offset}");