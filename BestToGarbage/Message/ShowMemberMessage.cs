using BestToGarbage.Models;
using BestToGarbage.ViewModels;

namespace BestToGarbage.Message;

public record ShowMemberMessage(HlMemberViewModel MemberViewModel);