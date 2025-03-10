using Confluent.Kafka;
using Confluent.Kafka.SyncOverAsync;
using Confluent.SchemaRegistry;
using Confluent.SchemaRegistry.Serdes;

var schemaConfig = new SchemaRegistryConfig
{
  Url = "http://localhost:8081"
};

var SchemaRegistry = new CachedSchemaRegistryClient(schemaConfig);

var config = new ConsumerConfig
{
    GroupId = "devby",
    BootstrapServers = "localhost:9092"
};

using var consumer = new ConsumerBuilder<string, dev.by.Curso>(config)
.SetValueDeserializer(new AvroDeserializer<dev.by.Curso>(SchemaRegistry).AsSyncOverAsync())
.Build();

consumer.Subscribe("cursos");

while (true)
{
    var result = consumer.Consume();
    Console.WriteLine($"Mensagem: {result.Message.Value.descricao}");
}