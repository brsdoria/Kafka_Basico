// Importa a biblioteca do Confluent Kafka, necessária para comunicação com Kafka.
using Confluent.Kafka;
// Importa a biblioteca do Schema Registry do Confluent, que é usada para validar esquemas Avro.
using Confluent.SchemaRegistry;
// Importa a biblioteca de Serializadores do Schema Registry, que lida com a serialização e desserialização dos dados.
using Confluent.SchemaRegistry.Serdes;
// Importa o namespace onde o tipo "Curso" está localizado (provavelmente o seu modelo de dados).
using Produtor.dev.by;

// Configuração do Schema Registry, incluindo a URL do servidor de registros e as credenciais de autenticação.
var schemaConfig = new SchemaRegistryConfig
{
  // URL do servidor Schema Registry
  Url = "http://localhost:8081",BasicAuthUserInfo=""
};

// Cria um cliente para acessar o Schema Registry e armazenar o esquema em cache.
var SchemaRegistry = new CachedSchemaRegistryClient(schemaConfig);

// Configuração do produtor Kafka, especificando o servidor de bootstrap (Kafka).
var config = new ProducerConfig{ BootstrapServers = "localhost:9092" };

// Cria uma instância de produtor Kafka, com chave do tipo string e valor do tipo "Curso" serializado em Avro.
using var producer = new ProducerBuilder<string, dev.by.Curso>(config)
// Define o serializador Avro para o valor
.SetValueSerializer(new AvroSerializer<dev.by.Curso>(SchemaRegistry))
// Constrói o produtor
.Build();

// Cria um objeto para gerar cursos aleatórios.
 GeradorDeCursos gerador = new GeradorDeCursos(); 
 // Gera um nome de curso aleatório usando o gerador.
 string NomeCursoAleatorio = gerador.GerarNomeCurso();

// Cria uma mensagem Kafka com uma chave do tipo string e valor do tipo "Curso".
var message = new Message<string, dev.by.Curso>
{
  // Gera uma chave única (UUID) para a mensagem
    Key = Guid.NewGuid().ToString(),
    // Cria o objeto "Curso" com valores preenchidos
    Value = new dev.by.Curso
    {
      // Gera um ID único para o curso
        id = Guid.NewGuid().ToString(),
        // Atribui a descrição gerada aleatoriamente ao curso
        descricao = NomeCursoAleatorio
    }
};

// Envia a mensagem para o tópico "cursos" e aguarda o resultado da produção assíncrona.
var result = await producer.ProduceAsync("cursos", message);

// Exibe o tópico, partição e offset onde a mensagem foi produzida.
Console.WriteLine($"Tópico: {result.Topic}, Partição {result.Partition} e Offset {result.Offset}");