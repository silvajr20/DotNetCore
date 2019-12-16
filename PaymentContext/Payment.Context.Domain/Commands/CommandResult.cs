using Payment.Context.Shared.Handlers;

namespace Payment.Context.Domain.Commands{

    public class CommandResults : ICommandResult
    {
        public CommandResults()
        {

        }
        
        public CommandResults(bool sucess, string message)
        {
            this.sucess = sucess;
            this.message = message;
        }         

        public bool sucess { set; get;}
        public string message { set; get;}

    }
}