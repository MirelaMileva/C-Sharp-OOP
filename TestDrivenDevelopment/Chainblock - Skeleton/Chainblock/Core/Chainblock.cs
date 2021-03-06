﻿using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

using Chainblock.Common;
using Chainblock.Contracts;

namespace Chainblock.Core
{
    public class Chainblock : IChainblock
    {
        private ICollection<ITransaction> transactions;
        public Chainblock()
        {
            this.transactions = new List<ITransaction>();
        }
        public int Count => this.transactions.Count;

        public void Add(ITransaction tx)
        {
            if (this.Contains(tx))
            {
                throw new InvalidOperationException(ExceptionMessages.AddingExistingTransactionMessage);
            }

            this.transactions.Add(tx);
        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            ITransaction transaction = this.transactions.FirstOrDefault(tx => tx.Id == id);

            if (transaction == null)
            {
                throw new ArgumentException(ExceptionMessages.ChangingStatusOfNonExistingTr);
            }

            transaction.Status = newStatus;
        }

        public bool Contains(ITransaction tx)
        {
            return this.Contains(tx.Id);
        }

        public bool Contains(int id)
        {
            bool isContained = this.transactions.Any(tx => tx.Id == id);

            return isContained;
        }

        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            IEnumerable<ITransaction> transactions = this.transactions
                .OrderByDescending(tx => tx.Amount)
                .ThenBy(tx => tx.Id);

            return transactions;
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            IEnumerable<string> receivers = this.GetByTransactionStatus(status).Select(tx => tx.To);

            return receivers;
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            IEnumerable<string> senders = this.GetByTransactionStatus(status).Select(tx => tx.From);

            return senders;
        }

        public ITransaction GetById(int id)
        {
            ITransaction transaction = this.transactions.FirstOrDefault(tx => tx.Id == id);

            if (transaction == null)
            {
                throw new InvalidOperationException(ExceptionMessages.NonExistingTransactionMessage);
            }

            return transaction;
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            IEnumerable<ITransaction> transactions = this.transactions.Where(tx => tx.To == receiver).OrderByDescending(tx => tx.Amount).ThenBy(tx => tx.Id);

            if (transactions.Count() == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.NoTransactionsForGivenReceiverMessage);
            }

            return transactions;
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            IEnumerable<ITransaction> transactions = this.transactions.Where(tx => tx.From == sender).OrderByDescending(tx => tx.Amount);

            if (transactions.Count() == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.NoTransactionsForGivenSenderMessage);
            }

            return transactions;
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            IEnumerable<ITransaction> transactions = this.transactions.Where(tx => tx.Status == status).OrderByDescending(tx => tx.Amount);

            if (transactions.Count() == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyStatusTrCollection);
            }

            return transactions;
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            throw new System.NotImplementedException();
        }
        public void RemoveTransactionById(int id)
        {
            try
            {
                ITransaction transaction = this.GetById(id);

                this.transactions.Remove(transaction);
            }
            catch (InvalidOperationException ioe)
            {
                throw new InvalidOperationException(ExceptionMessages.RemovingNonExistingTransactionMessage, ioe);
            }
        }

        public IEnumerator<ITransaction> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.transactions.ToArray()[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
