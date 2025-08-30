using System.Collections.Generic;
using System.Collections.ObjectModel;
using BestToGarbage.Models;

namespace BestToGarbage.Message;

public record UpdateHlMessage(ObservableCollection<HlModel> Models);