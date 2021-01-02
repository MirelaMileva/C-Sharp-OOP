using Chainblock.Common;
using Chainblock.Contracts;
using Chainblock.Models;

using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;

namespace Chainblock.Tests
{
    [TestFixture]
    public class ChainblockTests
    {
        private IChainblock chainblock;
        private ITransaction testTransaction;

        [SetUp]
        public void SetUp()
        {
            this.chainblock = new Core.Chainblock();
            this.testTransaction = new Transaction(1, TransactionStatus.Unauthorized, "Pesho", "Gosho", 10);
        }

        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            int expectedInitialCount = 0;

            IChainblock chainblock = new Chainblock.Core.Chainblock();

            Assert.AreEqual(expectedInitialCount, chainblock.Count);
        }

        [Test]
        public void AddShouldIncreaseCountWhenSuccess()
        {
            //Arrange
            int expectedCount = 1;

            ITransaction transaction = new Transaction(1, TransactionStatus.Successfull
                , "Pesho", "Gosho", 10);

            //Act
            this.chainblock.Add(transaction);

            //Assert
            Assert.AreEqual(expectedCount, this.chainblock.Count);
        }

        [Test]
        public void AddingExistingTransactionShouldThrowAnException()
        {
            //Arrange
            ITransaction transaction = new Transaction(1, TransactionStatus.Failed, "Pesho", "Gosho", 10);

            this.chainblock.Add(transaction);

            Assert.That(() =>
            {
                this.chainblock.Add(transaction);
            }, Throws.InvalidOperationException.With.Message.EqualTo(ExceptionMessages.AddingExistingTransactionMessage));
        }

        [Test]
        public void AddingSameTransactionWithAnotherIdShouldPass()
        {
            //Arrange
            int expectedCount = 2;

            TransactionStatus ts = TransactionStatus.Successfull;
            string from = "Pesho";
            string to = "Gosho";
            double amount = 10;

            ITransaction transaction = new Transaction(1, ts, from, to, amount);
            ITransaction transactionCopy = new Transaction(2, ts, from, to, amount);

            //Act
            this.chainblock.Add(transaction);
            this.chainblock.Add(transactionCopy);

            //Assert
            Assert.AreEqual(expectedCount, this.chainblock.Count);
        }

        [Test]
        public void ContainsByTransactionShouldReturnTrueWithExcistingTransaction()
        {
            int id = 1;
            TransactionStatus ts = TransactionStatus.Failed;
            string from = "Pesho";
            string to = "Gosho";
            double amount = 10;

            ITransaction transaction = new Transaction(id, ts, from, to, amount);

            this.chainblock.Add(transaction);

            Assert.IsTrue(this.chainblock.Contains(transaction));
        }

        [Test]
        public void ContainsByTransactionShouldReturnFalseWithNonExcistingTransaction()
        {
            int id = 1;
            TransactionStatus ts = TransactionStatus.Failed;
            string from = "Pesho";
            string to = "Gosho";
            double amount = 10;

            ITransaction transaction = new Transaction(id, ts, from, to, amount);

            // no add to transaction
            //this.chainblock.Add(transaction);

            Assert.IsFalse(this.chainblock.Contains(transaction));
        }


        [Test]
        public void ContainsByIdShouldReturnTrueWithExistingTransaction()
        {
            int id = 1;
            TransactionStatus ts = TransactionStatus.Failed;
            string from = "Pesho";
            string to = "Gosho";
            double amount = 10;

            ITransaction transaction = new Transaction(id, ts, from, to, amount);

            this.chainblock.Add(transaction);

            Assert.IsTrue(this.chainblock.Contains(id));
        }

        [Test]
        public void ContainsByIdShouldReturnFalseWithNonExistingTransaction()
        {
            int id = 1;
            TransactionStatus ts = TransactionStatus.Failed;
            string from = "Pesho";
            string to = "Gosho";
            double amount = 10;

            ITransaction transaction = new Transaction(id, ts, from, to, amount);

            // no add to transaction
            //this.chainblock.Add(transaction);

            Assert.IsFalse(this.chainblock.Contains(id));
        }

        [Test]
        public void ChangeExistingTransactionStatusShouldSuccess()
        {
            //Arrange
            int id = 1;
            TransactionStatus ts = TransactionStatus.Unauthorized;
            string from = "Pesho";
            string to = "Gosho";
            double amount = 10;

            TransactionStatus newStatus = TransactionStatus.Successfull;

            ITransaction transaction = new Transaction(id, ts, from, to, amount);

            this.chainblock.Add(transaction);

            //Act
            this.chainblock.ChangeTransactionStatus(id, newStatus);

            //Assert
            Assert.AreEqual(newStatus, transaction.Status);
        }

        [Test]
        public void ChangingStatusOfNonExistingTransactionShouldThrowException()
        {
            //Arrange
            int id = 1;
            TransactionStatus ts = TransactionStatus.Unauthorized;
            string from = "Pesho";
            string to = "Gosho";
            double amount = 10;

            int fakeId = 13;
            TransactionStatus newStatus = TransactionStatus.Successfull;

            ITransaction transaction = new Transaction(id, ts, from, to, amount);

            this.chainblock.Add(transaction);

            //Act
            Assert.That(() =>
            {
                this.chainblock.ChangeTransactionStatus(fakeId, newStatus);
            }, Throws.ArgumentException.With.Message.EqualTo(ExceptionMessages.ChangingStatusOfNonExistingTr));

        }

        [Test]
        public void GetByIdShouldReturnCorrectTransaction()
        {
            int id = 2;
            TransactionStatus ts = TransactionStatus.Successfull;
            string from = "Sender";
            string to = "Receiver";
            double amount = 20;
            ITransaction transaction = new Transaction(id, ts, from, to, amount);

            this.chainblock.Add(testTransaction);
            this.chainblock.Add(transaction);

            ITransaction returnedTransaction = this.chainblock.GetById(id);

            Assert.AreEqual(transaction, returnedTransaction);
        }

        [Test]
        public void GetByIdShouldThrowAnExceptionWhenTryingToFindNonExistingTr()
        {
            int id = 2;
            TransactionStatus ts = TransactionStatus.Successfull;
            string from = "Sender";
            string to = "Receiver";
            double amount = 20;

            int fakeId = 13;

            ITransaction transaction = new Transaction(id, ts, from, to, amount);

            this.chainblock.Add(testTransaction);
            this.chainblock.Add(transaction);

            Assert.That(() =>
            {
                this.chainblock.GetById(fakeId);
            }, Throws.InvalidOperationException.With.Message.EqualTo(ExceptionMessages.NonExistingTransactionMessage));
        }

        [Test]
        public void RemovingTransactionShouldDecreaseCount()
        {
            int id = 2;
            TransactionStatus ts = TransactionStatus.Successfull;
            string from = "Gosho";
            string to = "Pesho";
            double amount = 250;

            int expectedCount = 1;

            ITransaction transaction = new Transaction(id, ts, from, to, amount);

            this.chainblock.Add(testTransaction);
            this.chainblock.Add(transaction);

            this.chainblock.RemoveTransactionById(id);

            Assert.AreEqual(expectedCount, this.chainblock.Count);
        }

        [Test]
        public void RemovingTransctionShouldPhysicallyRemoveTransaction()
        {
            int id = 2;
            TransactionStatus ts = TransactionStatus.Successfull;
            string from = "Gosho";
            string to = "Pesho";
            double amount = 250;

            //int expectedCount = 1;

            ITransaction transaction = new Transaction(id, ts, from, to, amount);

            this.chainblock.Add(testTransaction);
            this.chainblock.Add(transaction);

            this.chainblock.RemoveTransactionById(id);

            Assert.That(() =>
            {
                this.chainblock.GetById(id);
            }, Throws.InvalidOperationException.With.Message.EqualTo(ExceptionMessages.NonExistingTransactionMessage));
        }

        [Test]
        public void RemovingNonExistingTransactionShouldThrowException()
        {
            int id = 2;
            TransactionStatus ts = TransactionStatus.Successfull;
            string from = "Gosho";
            string to = "Pesho";
            double amount = 250;

            int fakeId = 13;

            ITransaction transaction = new Transaction(id, ts, from, to, amount);

            this.chainblock.Add(testTransaction);
            this.chainblock.Add(transaction);

            Assert.That(() =>
            {
                this.chainblock.RemoveTransactionById(fakeId);
            }, Throws.InvalidOperationException.With.Message.EqualTo(ExceptionMessages.RemovingNonExistingTransactionMessage));

        }

        [Test]
        public void GetByTransactionStatusShouldReturnOrderedCollectionWithRightTransaction()
        {
            ICollection<ITransaction> expTransactions = new List<ITransaction>();

            for (int i = 0; i < 4; i++)
            {
                int id = i + 1;
                TransactionStatus ts = (TransactionStatus)i;
                string from = "Pesho" + i;
                string to = "Gosho" + i;
                double amount = 10;
                ITransaction currTr = new Transaction(id, ts, from, to, amount);

                if (ts == TransactionStatus.Successfull)
                {
                    expTransactions.Add(currTr);
                }

                this.chainblock.Add(currTr);
            }

            ITransaction succTr = new Transaction(5, TransactionStatus.Successfull, "Pesho4", "Gosho4", 15);

            expTransactions.Add(succTr);
            this.chainblock.Add(succTr);

            IEnumerable<ITransaction> actTransaction = this.chainblock.GetByTransactionStatus(TransactionStatus.Successfull);

            expTransactions = expTransactions.OrderByDescending(tx => tx.Amount).ToList();

            CollectionAssert.AreEqual(expTransactions, actTransaction);
        }

        [Test]
        public void TestGettingTransactionsWithNoExistingStatus()
        {
            for (int i = 0; i < 10; i++)
            {
                int id = i + 1;
                TransactionStatus ts = TransactionStatus.Failed;
                string from = "Pesho" + i;
                string to = "Gosho" + i;
                double amount = 10 * (i + 1);

                ITransaction currTr = new Transaction(id, ts, from, to, amount);

                this.chainblock.Add(currTr);
            }

            Assert.That(() =>
            {
                this.chainblock.GetByTransactionStatus(TransactionStatus.Successfull);
            }, Throws.InvalidOperationException.With.Message.EqualTo(ExceptionMessages.EmptyStatusTrCollection));
        }

        [Test]
        public void AllSendersByStatusShouldReturnCorrectOrderedCollection()
        {
            ICollection<ITransaction> transactions = new List<ITransaction>();

            for (int i = 0; i < 4; i++)
            {
                int id = i + 1;
                TransactionStatus ts = (TransactionStatus)i;
                string from = "Pesho" + i;
                string to = "Gosho" + i;
                double amount = 10;
                ITransaction currTr = new Transaction(id, ts, from, to, amount);

                if (ts == TransactionStatus.Successfull)
                {
                    transactions.Add(currTr);
                }

                this.chainblock.Add(currTr);
            }

            ITransaction succTr = new Transaction(5, TransactionStatus.Successfull, "Pesho4", "Gosho4", 15);

            transactions.Add(succTr);
            this.chainblock.Add(succTr);

            IEnumerable<string> actTransactions = this.chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Successfull);

            IEnumerable<string> expTransactions = transactions.OrderByDescending(tx => tx.Amount).Select(tx => tx.From);

            CollectionAssert.AreEqual(expTransactions, actTransactions);
        }

        [Test]
        public void AllSendersByStatusShouldThrowAnExceptionWhenThereAreNoTransactionWithGivenStatus()
        {
            for (int i = 0; i < 10; i++)
            {
                int id = i + 1;
                TransactionStatus ts = TransactionStatus.Failed;
                string from = "Pesho" + i;
                string to = "Gosho" + i;
                double amount = 10 * (i + 1);

                ITransaction currTr = new Transaction(id, ts, from, to, amount);

                this.chainblock.Add(currTr);
            }

            Assert.That(() => 
            {
                this.chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Successfull);
            }, Throws.InvalidOperationException.With.Message.EqualTo(ExceptionMessages.EmptyStatusTrCollection));
        }

        [Test]
        public void AllReceiversByStatusShouldReturnCorrectOrderedCollection()
        {
            ICollection<ITransaction> transactions = new List<ITransaction>();

            for (int i = 0; i < 4; i++)
            {
                int id = i + 1;
                TransactionStatus ts = (TransactionStatus)i;
                string from = "Pesho" + i;
                string to = "Gosho" + i;
                double amount = 10;
                ITransaction currTr = new Transaction(id, ts, from, to, amount);

                if (ts == TransactionStatus.Successfull)
                {
                    transactions.Add(currTr);
                }

                this.chainblock.Add(currTr);
            }

            ITransaction succTr = new Transaction(5, TransactionStatus.Successfull, "Pesho4", "Gosho4", 15);

            transactions.Add(succTr);
            this.chainblock.Add(succTr);

            IEnumerable<string> actTransactions = this.chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Successfull);

            IEnumerable<string> expTransactions = transactions.OrderByDescending(tx => tx.Amount).Select(tx => tx.To);

            CollectionAssert.AreEqual(expTransactions, actTransactions);
        }

        [Test]
        public void AllReceiversByStatusShouldThrowAnExceptionWhenThereAreNoTransactionWithGivenStatus()
        {
            for (int i = 0; i < 10; i++)
            {
                int id = i + 1;
                TransactionStatus ts = TransactionStatus.Failed;
                string from = "Pesho" + i;
                string to = "Gosho" + i;
                double amount = 10 * (i + 1);

                ITransaction currTr = new Transaction(id, ts, from, to, amount);

                this.chainblock.Add(currTr);
            }

            Assert.That(() =>
            {
                this.chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Successfull);
            }, Throws.InvalidOperationException.With.Message.EqualTo(ExceptionMessages.EmptyStatusTrCollection));
        }

        [Test]
        public void TestGetAllOrderedByAmountThenByIDWithNoDuplicatedAmounts()
        {
            ICollection<ITransaction> expTransactions = new List<ITransaction>();

            for (int i = 0; i < 10; i++)
            {
                int id = i + 1;
                TransactionStatus ts = (TransactionStatus)(i % 4);
                string from = "Pesho" + i;
                string to = "Gosho" + i;
                double amount = 10 + i;

                ITransaction currTr = new Transaction(id, ts, from, to, amount);

                this.chainblock.Add(currTr);
                expTransactions.Add(currTr);
            }

            IEnumerable<ITransaction> actTransactions = this.chainblock.GetAllOrderedByAmountDescendingThenById();

            expTransactions = expTransactions
                .OrderByDescending(tx => tx.Amount)
                .ThenBy(tx => tx.Id)
                .ToList();

            CollectionAssert.AreEqual(expTransactions, actTransactions);
        }

        [Test]
        public void TestGetAllOrderedByAmountThenByIdWithDuplicatedAmounts()
        {
            ICollection<ITransaction> expTransactions = new List<ITransaction>();

            for (int i = 0; i < 10; i++)
            {
                int id = i + 1;
                TransactionStatus ts = (TransactionStatus)(i % 4);
                string from = "Pesho" + i;
                string to = "Gosho" + i;
                double amount = 10 + i;

                ITransaction currTr = new Transaction(id, ts, from, to, amount);

                this.chainblock.Add(currTr);
                expTransactions.Add(currTr);
            }

            ITransaction transaction = new Transaction(11, TransactionStatus.Successfull, "Gosho11", "Pesho11", 10);

            this.chainblock.Add(transaction);
            expTransactions.Add(transaction);

            IEnumerable<ITransaction> actTransactions = this.chainblock.GetAllOrderedByAmountDescendingThenById();

            expTransactions = expTransactions
                .OrderByDescending(tx => tx.Amount)
                .ThenBy(tx => tx.Id)
                .ToList();

            CollectionAssert.AreEqual(expTransactions, actTransactions);
        }

        [Test]
        public void TestGetAllOrderedByAmountThenByIdWithEmptyCollection()
        {
            IEnumerable<ITransaction> actTr = this.chainblock.GetAllOrderedByAmountDescendingThenById();

            CollectionAssert.IsEmpty(actTr);
        }

        [Test]
        public void TestIfGetAllBySenderDescendingByAmountWorkCorrectly()
        {
            ICollection<ITransaction> expTransactions = new List<ITransaction>();

            string wantedSender = "Pesho";

            for (int i = 0; i < 4; i++)
            {
                int id = i + 1;
                TransactionStatus ts = TransactionStatus.Successfull;
                string from = wantedSender;
                string to = "Gosho" + i;
                double amount = 10 + i;

                ITransaction currTr = new Transaction(id, ts, from, to, amount);

                expTransactions.Add(currTr);
                this.chainblock.Add(currTr);
            }

            for (int i = 4; i < 10; i++)
            {
                int id = i + 1;
                TransactionStatus ts = TransactionStatus.Successfull;
                string from = "Pesho" + 1;
                string to = "Gosho" + i;
                double amount = 20 + i;

                ITransaction currTr = new Transaction(id, ts, from, to, amount);

                this.chainblock.Add(currTr);
            }

            IEnumerable<ITransaction> actTransaction = this.chainblock
                .GetBySenderOrderedByAmountDescending(wantedSender);

            expTransactions = expTransactions
                .OrderByDescending(tx => tx.Amount)
                .ToList();

            CollectionAssert.AreEqual(expTransactions, actTransaction);
        }

        [Test]
        public void TestGetAllByNonExistingSenderDescendingByAmount()
        {
            for (int i = 0; i < 4; i++)
            {
                int id = i + 1;
                TransactionStatus ts = TransactionStatus.Successfull;
                string from = "Pesho" + i;
                string to = "Gosho" + i;
                double amount = 10 + i;

                ITransaction currTr = new Transaction(id, ts, from, to, amount);

                this.chainblock.Add(currTr);
            }

            string wantedSender = "Pesho";

            Assert.That(() => 
            {
                this.chainblock.GetBySenderOrderedByAmountDescending(wantedSender);
            }, Throws.InvalidOperationException.With.Message.EqualTo(ExceptionMessages.NoTransactionsForGivenSenderMessage));
        }

        [Test]
        public void TestGetByReceiverDescendingByAmountWorksCorrectlyWithNoDuplicatedAmounts()
        {
            ICollection<ITransaction> expTransactions = new List<ITransaction>();

            string wantedReceiver = "Gosho";

            for (int i = 0; i < 4; i++)
            {
                int id = i + 1;
                TransactionStatus ts = TransactionStatus.Successfull;
                string from = "Pesho" + i;
                string to = wantedReceiver;
                double amount = 10 + i;

                ITransaction currTr = new Transaction(id, ts, from, to, amount);

                expTransactions.Add(currTr);
                this.chainblock.Add(currTr);
            }

            for (int i = 4; i < 10; i++)
            {
                int id = i + 1;
                TransactionStatus ts = TransactionStatus.Successfull;
                string from = "Pesho" + i;
                string to = "Gosho" + i;
                double amount = 20 + i;

                ITransaction currTr = new Transaction(id, ts, from, to, amount);

                this.chainblock.Add(currTr);
            }

            IEnumerable<ITransaction> actTr = this.chainblock.GetByReceiverOrderedByAmountThenById(wantedReceiver);

            expTransactions = expTransactions
                .OrderByDescending(tx => tx.Amount)
                .ThenBy(tx => tx.Id)
                .ToList();

            CollectionAssert.AreEqual(expTransactions, actTr);
        }

        [Test]
        public void TestGetByReceiverDescendingByAmountWithDuplicatedAmounts()
        {
            ICollection<ITransaction> expTransactions = new List<ITransaction>();

            string wantedReceiver = "Gosho";

            for (int i = 0; i < 4; i++)
            {
                int id = i + 1;
                TransactionStatus ts = TransactionStatus.Successfull;
                string from = "Pesho" + i;
                string to = wantedReceiver;
                double amount = 10 + i;

                ITransaction currTr = new Transaction(id, ts, from, to, amount);

                expTransactions.Add(currTr);
                this.chainblock.Add(currTr);
            }

            for (int i = 4; i < 10; i++)
            {
                int id = i + 1;
                TransactionStatus ts = TransactionStatus.Successfull;
                string from = "Pesho" + i;
                string to = "Gosho" + i;
                double amount = 20 + i;

                ITransaction currTr = new Transaction(id, ts, from, to, amount);

                this.chainblock.Add(currTr);
            }

            ITransaction transaction = new Transaction(11, TransactionStatus.Successfull, "Pesho11", wantedReceiver, 10);

            IEnumerable<ITransaction> actTr = this.chainblock.GetByReceiverOrderedByAmountThenById(wantedReceiver);

            expTransactions = expTransactions
                .OrderByDescending(tx => tx.Amount)
                .ThenBy(tx => tx.Id)
                .ToList();

            CollectionAssert.AreEqual(expTransactions, actTr);
        }

        [Test]
        public void GetByReceiverDescendingByAmountThenByIdShouldThrowExceptionWhenNotransactionsFound()
        {
            for (int i = 0; i < 4; i++)
            {
                int id = i + 1;
                TransactionStatus ts = TransactionStatus.Successfull;
                string from = "Pesho" + i;
                string to = "Gosho" + i;
                double amount = 10 + i;

                ITransaction currTr = new Transaction(id, ts, from, to, amount);

                this.chainblock.Add(currTr);
            }

            string wantedReceiver = "Gosho";

            Assert.That(() => 
            {
                this.chainblock.GetByReceiverOrderedByAmountThenById(wantedReceiver);
            }, Throws.InvalidOperationException.With.Message.EqualTo(ExceptionMessages.NoTransactionsForGivenReceiverMessage));
        }

        [Test]
        public void TestChainblockEnumerator()
        {
            ICollection<ITransaction> addTransactions = new List<ITransaction>();
            ICollection<ITransaction> actTr = new List<ITransaction>();

            for (int i = 0; i < 4; i++)
            {
                int id = i + 1;
                TransactionStatus ts = TransactionStatus.Successfull;
                string from = "Pesho" + i;
                string to = "Gosho" + i;
                double amount = 10 + i;

                ITransaction currTr = new Transaction(id, ts, from, to, amount);

                addTransactions.Add(currTr);
                this.chainblock.Add(currTr);
            }

            foreach (ITransaction tr in this.chainblock)
            {
                actTr.Add(tr);
            }

            CollectionAssert.AreEqual(addTransactions, actTr);
        }
    }
}
