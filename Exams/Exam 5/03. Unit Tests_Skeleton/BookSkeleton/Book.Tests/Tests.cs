namespace Book.Tests
{
    using System;

    using NUnit.Framework;
    using static System.Net.Mime.MediaTypeNames;

    public class Tests
    {
        [TestCase("12 Rules for Life")]
        [TestCase("12 More Rules for Life")]
        public void ConstructorShouldSetBookName(string bookName)
        {
            Book book = new Book(bookName, "Jordan Peterson");

            Assert.That(book.BookName, Is.EqualTo(bookName));
        }

        [TestCase("")]
        [TestCase(null)]
        public void ConstructorWithInvalidBookNameShouldThrowException(string bookName)
        {
            Assert.Throws<ArgumentException>(() => new Book(bookName, "Jordan Peterson"));
        }

        [TestCase("Ray Dalio")]
        [TestCase("MJ DeMarco")]
        public void ConstructorShouldSetAuthorName(string authorName)
        {
            Book book = new Book("Principles", authorName);

            Assert.That(book.Author, Is.EqualTo(authorName));
        }

        [TestCase("")]
        [TestCase(null)]
        public void ConstructorWithInvalidAuthorNameShouldThrowException(string authorName)
        {
            Assert.Throws<ArgumentException>(() => new Book("The Millionaire Fastlane", authorName));
        }

        [Test]
        public void ConstructorShouldInitializeTheCollection()
        {
            Book book = new Book("The Fine Art of Small Talk", "Debra Fine");

            Assert.That(book.FootnoteCount, Is.EqualTo(0));
        }

        [Test]
        public void AddFootnoteMethodShouldAddTheGivenFootnote()
        {
            Book book = new Book("The Fine Art of Small Talk", "Debra Fine");
            book.AddFootnote(1, "something");

            Assert.That(book.FootnoteCount, Is.EqualTo(1));
        }

        [Test]
        public void DuplicatingFootnoteShouldThrowException()
        {
            Book book = new Book("The Fine Art of Small Talk", "Debra Fine");
            book.AddFootnote(1, "something");

            Assert.Throws<InvalidOperationException>(() => book.AddFootnote(1, "another thing"));
        }

        [Test]
        public void FindFootnoteShouldReturnTheFootnoteWithTheGivenNumber()
        {
            Book book = new Book("The Fine Art of Small Talk", "Debra Fine");
            book.AddFootnote(1, "something");

            string expectedOutput = $"Footnote #1: something";

            Assert.That(book.FindFootnote(1), Is.EqualTo(expectedOutput));
        }

        [Test]
        public void FindFootnoteWithInvalidNumberShouldThrowException()
        {
            Book book = new Book("The Fine Art of Small Talk", "Debra Fine");

            Assert.Throws<InvalidOperationException>(() => book.FindFootnote(1));
        }

        [Test]
        public void AlterFootnoteShouldSetNewValueToAFootnote()
        {
            Book book = new Book("The Fine Art of Small Talk", "Debra Fine");

            book.AddFootnote(1, "something");
            book.AlterFootnote(1, "altered text");
            string expectedOutput = $"Footnote #1: altered text";

            Assert.That(book.FindFootnote(1), Is.EqualTo(expectedOutput));
        }

        [Test]
        public void AlterFootnoteWithInvalidNumberShouldThrowException()
        {
            Book book = new Book("The Fine Art of Small Talk", "Debra Fine");

            Assert.Throws<InvalidOperationException>(() => book.AlterFootnote(1, ""));
        }
    }
}