// Importa a biblioteca do Confluent Kafka, necessária para comunicação com Kafka.
using Confluent.Kafka;
// Importa a biblioteca SyncOverAsync, que permite usar métodos assíncronos de maneira síncrona, útil para deserialização.
using Confluent.Kafka.SyncOverAsync;
// Importa a biblioteca do Schema Registry do Confluent, usada para validar esquemas Avro.
using Confluent.SchemaRegistry;
// Importa a biblioteca de Serializadores e Deserializadores do Schema Registry, que lida com a serialização e desserialização dos dados.
using Confluent.SchemaRegistry.Serdes;

// Configuração do Schema Registry, incluindo a URL do servidor de registros.
var schemaConfig = new SchemaRegistryConfig
{
  // Define a URL do servidor do Schema Registry
  Url = "http://localhost:8081"
};

// Cria um cliente para acessar o Schema Registry e armazenar o esquema em cache.
var SchemaRegistry = new CachedSchemaRegistryClient(schemaConfig);

// Configuração do consumidor Kafka, especificando o grupo de consumidores e o servidor de bootstrap (Kafka).
var config = new ConsumerConfig
{
  // Define o ID do grupo de consumidores, que permite o balanceamento de carga entre consumidores.
    GroupId = "devby",
    // Define o servidor de bootstrap Kafka.
    BootstrapServers = "localhost:9092"
};

// Cria uma instância de consumidor Kafka, com chave do tipo string e valor do tipo "Curso" deserializado em Avro.
using var consumer = new ConsumerBuilder<string, dev.by.Curso>(config)
// Define o desserializador Avro para o valor e usa o SyncOverAsync para operações síncronas.
.SetValueDeserializer(new AvroDeserializer<dev.by.Curso>(SchemaRegistry).AsSyncOverAsync()) 
// Constrói o consumidor
.Build();

// Inscreve o consumidor no tópico "cursos" para receber mensagens.
consumer.Subscribe("cursos");

// Loop infinito para consumir as mensagens continuamente.
while (true)
{
    // Consome a próxima mensagem do tópico "cursos" e aguarda a chegada de uma mensagem.
    var result = consumer.Consume();
    // Exibe o conteúdo da descrição da mensagem recebida.
    Console.WriteLine($"Mensagem: {result.Message.Value.descricao}");
}