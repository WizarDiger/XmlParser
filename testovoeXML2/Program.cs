using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Intrinsics.X86;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using testovoeXML2;
using testovoeXML2.Interfaces;
using testovoeXML2.Models;
using testovoeXML2.Repositories;

var serviceProvider = new ServiceProviderFactory().Create();
XmlManager? xmlManager = serviceProvider.GetRequiredService<XmlManager>();
xmlManager?.InitializeParsing(serviceProvider);