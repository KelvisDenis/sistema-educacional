﻿using System.ComponentModel.DataAnnotations;

namespace SistemaEducacional.Models
{
    /// <summary>
    /// classe representa a entidade aluno no banco de dados
    /// </summary>
    public class AlunoModel
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string? Nome { get; set; }
        [Required]
        [StringLength(11)]
        public string? Cpf { get; set; }
        [Required]
        [DataType(DataType.Date)]
        
        public DateTime? DataNascimento { get; set; }
        public int? IdTurma { get; set; }
     
        public int? IdNota { get;  set; }
        [EmailAddress()]
        public string? Email { get;  set; }
        [StringLength(maximumLength: 80,MinimumLength =8)]
        public string? SenhaTemporaria { get; set; }
        public ICollection<NotasModel>? Notas { get; set; }  

        /// <summary>
        /// Construtores da classe
        /// </summary>
        public AlunoModel() { }

        public AlunoModel(int id, string? nome, string? cpf,string? email, string? senha,
            DateTime? dataNascimento, int? idTurma)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            DataNascimento = dataNascimento;
            IdTurma = idTurma;
            Email = email;
            SenhaTemporaria = senha;
        }
        /// <summary>
        /// varifica se a data, para ser menor que a do presente momento
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public bool CheckDate(DateTime? date)
        {
            var check = (date < DateTime.Now );
            return check;
        }
    }
}
