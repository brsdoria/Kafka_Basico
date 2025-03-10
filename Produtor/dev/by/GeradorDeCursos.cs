using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Produtor.dev.by
{
    internal class GeradorDeCursos
    {
        // Listas de palavras para criar os nomes dos cursos
        private string[] temas = {
        "Tecnologia", "Gestão", "Saúde", "Negócios", "Design",
        "Marketing", "Programação", "Finanças", "Desenvolvimento", "Psicologia"
    };

        private string[] modalidades = {
        "Online", "Presencial", "Híbrido", "Intensivo", "Avançado",
        "Básico", "Profissional", "Prático", "Teórico"
    };

        private string[] adjetivos = {
        "Inovador", "Avançado", "Fundamental", "Expert", "Rápido",
        "Eficiente", "Prático", "Inteligente", "Criativo", "Estratégico"
    };

        private string[] sufixos = {
        "e Estratégias", "e Soluções", "e Tecnologias", "para o Futuro",
        "e Resultados", "e Performance", "para Iniciantes", "e Carreira",
        "para Empreendedores", "e Inovação"
    };

        private Random random;

        // Construtor
        public GeradorDeCursos()
        {
            random = new Random();
        }

        // Método para gerar o nome do curso
        public string GerarNomeCurso()
        {
            // Escolhe aleatoriamente uma palavra de cada lista
            string tema = temas[random.Next(temas.Length)];
            string modalidade = modalidades[random.Next(modalidades.Length)];
            string adjetivo = adjetivos[random.Next(adjetivos.Length)];
            string sufixo = sufixos[random.Next(sufixos.Length)];

            // Gera o nome completo do curso
            return $"{adjetivo} {tema} {modalidade} {sufixo}";
        }
    }
}
