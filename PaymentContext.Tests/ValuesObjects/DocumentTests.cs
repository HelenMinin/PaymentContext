using System.Reflection;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.ValuesObjects;

[TestClass]
public class DocumentTests
{
    [TestMethod]
    [DataRow("123.456.789-87", DisplayName = "CPF com mascara")]
    [DataRow("12345678987", DisplayName = "CPF sem mascara")]
    [DataRow("", DisplayName = "Vazio")]
    [DataRow(" ", DisplayName = "Em branco")]
    [DataRow(null, DisplayName = "Nulo")]
    public void ShouldReturnErrorWhenCNPJIsInvalid(string cnpj)
    {
        var doc = new Document(cnpj, EDocumentType.CNPJ);

        var result = doc.IsDocumentValid();
        
        Assert.IsFalse(result);
    }
    
    [TestMethod]
    [DataRow("10.092.867/0001-78")]
    [DataRow("10092867000178")]
    public void ShouldReturnSuccessWhenCNPJIsValid(string cnpj)
    {
        var doc = new Document(cnpj, EDocumentType.CNPJ);

        var result = doc.IsDocumentValid();
        
        Assert.IsTrue(result);

    }
    
    [TestMethod]
    [DataRow("123.456.789-87")]
    [DataRow("12345678987")]
    public void ShouldReturnErrorWhenCpfIsInvalid(string cpf)
    {
        var doc = new Document(cpf, EDocumentType.CNPJ);

        var result = doc.IsDocumentValid();
        
        Assert.IsFalse(result);
    }
    
    [TestMethod]
    [DataRow("10.092.867/0001-78")]
    [DataRow("10092867000178")]
    public void ShouldReturnSuccessWhenCpfIsValid(string cpf)
    {
        var doc = new Document(cpf, EDocumentType.CNPJ);

        var result = doc.IsDocumentValid();
        
        Assert.IsTrue(result);
    }
}