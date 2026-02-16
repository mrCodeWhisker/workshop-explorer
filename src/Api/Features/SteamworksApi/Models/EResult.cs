namespace Api.Features.SteamworksApi.Models;

public enum EResult
{
    OK = 1,
    Fail = 2,
    NoConnection = 3,
    InvalidPassword = 5,
    LoggedInElsewhere = 6,
    InvalidProtocolVersion = 7,
    InvalidParameter = 8,
    FileNotFound = 9,
    Busy = 10,
    InvalidState = 11,
    InvalidName = 12,
    InvalidEmail = 13,
    DuplicateName = 14,
    AccessDenied = 15,
    Timeout = 16,
    Banned = 17,
    AccountNotFound = 18,
    InvalidSteamID = 19,
    ServiceUnavailable = 20
}
