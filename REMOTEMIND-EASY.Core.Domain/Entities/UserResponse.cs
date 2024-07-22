﻿namespace REMOTEMIND_EASY.Core.Domain.Entities
{
    public class UserResponse
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public Questions Question { get; set; }
        public int ResponseId { get; set; }
        public Responses Response { get; set; }
        public string? UserId { get; set; }
        public int? Value { get; set; }
    }
}
