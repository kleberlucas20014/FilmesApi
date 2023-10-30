﻿using System;

public class CreateFilmeDto
{
	public CreateFilmeDto()
	{
        
      
        public int Id { get; set; }
        [Required(ErrorMessage = "O título do filme é obrigatório")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O gênero do filme é obrigatório")]
        [stringLength(50, ErrorMessage = "O tamanho do gênero não pode exceder 50 caracteres")]
        public string Genero { get; set; }

        [Required]
        [Range(70, 300, ErrorMessage = "A duração deve ter entre 70 e 300 minutos")]
        public int Duracao { get; set; }
    }
}
