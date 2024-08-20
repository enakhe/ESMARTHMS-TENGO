using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESMART_HMS.Domain.Enum
{
    [Flags]
    public enum LOCK_SETTING
    {
        LS_REPLACE_EN = 0x01,     // Enable guest card replacement
        LS_LEAD_EN = 0x02,     // Enable lead mode
        LS_VALID_DATE_EN = 0x04,     // Enable validity period
        LS_FLOOR_RANGE_EN = 0x08,     // Check floor range
        LS_CHANEL_MODE_EN = 0x10,     // Channel mode
        LS_FORBID_TONGUE_ALARM = 0x20,  // Disable latch alarm
        LS_ALL_REPLACE = 0x40,     // Enable replacement for various card types
        LS_FLAG_BYTE2_EN = 0x80,     // Enable guest room flag byte 2
        LS_LOCK_IMMEDIATE_EN = 0x0100,   // Immediate lock after retracting the latch
        LS_NO_BACKLOCK_EN = 0x0200,   // Disable backlock check for all cards
        LS_NO_MUSIC_EN = 0x0400,   // Mute door open/close sound
        LS_PROMPT_CLOSE_EN = 0x0800,   // Prompt guest to close the door
        LS_NO_BLOCK_LIGHT_EN = 0x1000,   // No light prompt when backlocking
    }

    public enum ROOM_TYPE
    {
        RT_COMMON_ROOMS = 0x1,      // Common rooms and large suites
        RT_SUITE_ROOMS = 0x2,      // Small suites within a larger suite
        RT_FLOOR_GATE = 0x4,      // Floor gate
        RT_BUILDING_GATE = 0x8,      // Building gate
        RT_HOTEL_GATE = 0x10      // Hotel gate
    }

    enum ERROR_TYPE
    {
        OPR_OK = 1,      // Operation successful
        NO_CARD = -1,     // No card detected
        NO_RW_MACHINE = -2,     // No card reader detected
        INVALID_CARD = -3,     // Invalid card
        CARD_TYPE_ERROR = -4,     // Card type error
        RDWR_ERROR = -5,     // Read/write error
        PORT_NOT_OPEN = -6,     // Port not open
        END_OF_DATA_CARD = -7,     // End of data card
        INVALID_PARAMETER = -8,     // Invalid parameter
        INVALID_OPR = -9,     // Invalid operation
        OTHER_ERROR = -10,    // Other error
        PORT_IN_USED = -11,    // Port is already in use
        COMM_ERROR = -12,    // Communication error
        ERR_RECOVER_CLIENT = -13,    // Successfully recovered authorization code from the card reader

        ERR_CLIENT = -20,    // Client code error
        ERR_LOST = -21,    // Card was lost
        ERR_TIME_INVALID = -22,    // Time is invalid
        ERR_TIME_STOPED = -23,    // Card has been deactivated
        ERR_BACK_LOCKED = -24,    // Back locked
        ERR_BUILDING = -25,    // Incorrect building number
        ERR_FLOOR = -26,    // Incorrect floor number
        ERR_ROOM = -27,    // Incorrect room number
        ERR_LOW_BAT = -28,    // Low battery

        ERR_NOT_REGISTERED = -29,    // Not registered
        ERR_NO_CLIENT_DATA = -30,    // No authorization card information
        ERR_ROOMS_CNT_OVER = -31,    // Number of rooms exceeds available sectors
    };

    enum CARD_FLAGS
    {
        CF_BACK_LOCK_EN = 0x01,      // Enable back lock (various key cards)
        CF_CHANNEL_MODE = 0x02,      // Channel mode (various key cards)
        CF_DOUBLE_MODE = 0x04,      // Double mode in DJE environment; when paired with a guest card, the guest room time mark is merged. On 20191024, the guest card is moved to bit6 !!!!!!
        CF_CHECK_TIMESTAMP = 0x40,      // Update and check timestamp (guest card), used as a master card mark during the validity period	
        CF_NO_REPLACE = 0x08,      // Do not replace the previous card (guest card)	
        CF_IMPORT_ROOM = 0x10,      // Import room number for guest card
        CF_OPEN_ONCE = 0x20,      // Open the door only once (single-use guest card)
        CF_NEW_CARD = 0x40,      // In DLock version, indicates a new guest entry. Clear balance when copying guest card.
        CF_CHK_CHECKIN_TIME = 0x80,   // Check check-in time

        CF_PROHIBIT_DATA_EN = 0x10,      // Prohibit entry data for staff card	
        CF_REPLACE_EN = 0x40,      // Enable replacement (staff card)
        CF_AUTO_LOST_EN = 0x80,      // Auto-loss card (staff card)

        CF_CHECKOUT_GUEST_ONLY = 0x10,      // Only check out guest card
        CF_CHECKOUT_STAFF_ONLY = 0x20,      // Only check out staff card
        CF_WHOLE_BUILDING = 0x40,      // Whole building permission (room card)
        CF_WHOLE_HOTEL = 0x80,      // Whole system permission (room card)

        CF_JUDGE_CHECKIN_TIME = 0x80,      // Enable check-in time judgement (guest card)   

        CF_CHANGE_FLAGS = (0x01 << 16),   // Change lock flag
        CF_CLEAR_ROOM_INFO = (0x02 << 16),   // Clear guest room information (lock configuration card)
        CF_FORBID_CARDS = (0x04 << 16),   // Block room (lock configuration card)
        CF_SET_ONE_AREA = (0x08 << 16),   // Clear guest room information (lock configuration card)
        CF_CLR_ONE_AREA = (0x10 << 16),   // Block room (lock configuration card)
        CF_SET_ALL_AREA = (0x20 << 16),   // Clear guest room information (lock configuration card)
        CF_CLR_ALL_AREA = (0x40 << 16),   // Block room (lock configuration card)
        CF_SET_CHANNEL_TIME = (0x80 << 16),   // Set channel door time
    };


}
