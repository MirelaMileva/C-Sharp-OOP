namespace Chainblock.Common
{
    public static class ExceptionMessages
    {
        public static string InvalidIdMessage = "IDs cannot be zero or negative!";

        public static string InvalidSenderUsernameMessage = "Sender name cannot be empty or whitespace!";

        public static string InvalidReceiverUsernameMessage = "Receiver name cannot be empty or whitespace!";

        public static string InvalidTransactionAmountMessage = "Transaction amount should be greater than 0!";


        public static string AddingExistingTransactionMessage = "Transaction already exists in our records!";

        public static string ChangingStatusOfNonExistingTr = "You can't change the status of non existing transaction!";

        public static string NonExistingTransactionMessage = "Transaction with given ID not found!";

        public static string RemovingNonExistingTransactionMessage = "You cannot remove non existing transaction!";

        public static string EmptyStatusTrCollection = "There are not transaction matching provided transaction status!";

        public static string NoTransactionsForGivenSenderMessage = "There are no coresponding transactions to given sender name!";

        public static string NoTransactionsForGivenReceiverMessage = "There are no coresponding transactions to given receiver name!";
    }
}
