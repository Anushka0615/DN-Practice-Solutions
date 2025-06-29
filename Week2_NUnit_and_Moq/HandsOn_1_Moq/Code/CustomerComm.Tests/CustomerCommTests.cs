using NUnit.Framework;
using Moq;
using CustomerCommLib;

namespace CustomerCommLib
{
    [TestFixture]
    public class CustomerCommTest
    {
        private CustomerComm _customerComm;
        private Mock<IMailSender> _mockMailSender;

        [OneTimeSetUp]
        public void Setup()
        {
            _mockMailSender = new Mock<IMailSender>();
            _mockMailSender.Setup(m => m.SendMail(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            _customerComm = new CustomerComm(_mockMailSender.Object);
        }

        [TestCase]
        public void SendMailToCustomer_WhenCalled_ReturnsTrue()
        {
            bool result = _customerComm.SendMailToCustomer();
            Assert.That(result, Is.True);
        }
    }
}
