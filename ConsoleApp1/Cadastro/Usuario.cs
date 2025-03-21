class Usuario {
    // Criando objetos
    private String Nome {
        get;
        set;
    }
    private String Email{
       get;
       set;
    }
    private int Idade {
        get;
        set;
    }

   // Construtor do objeto
    public Usuario(String nome, String email, int idade){
      this.Nome = nome;
      this.Email = email;
      this.Idade = idade;
     
    }
     public string GetNome() => Nome;
      public string GetEmail() => Email;
      public int GetIdade() => Idade;
}