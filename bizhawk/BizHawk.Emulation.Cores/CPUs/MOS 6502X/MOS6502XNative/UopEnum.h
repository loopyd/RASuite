// AUTOGENERATED
#ifndef UOPENUM_H
#define UOPENUM_H
enum Uop {
	Uop_Unsupported, 
	Uop_Fetch1, 
	Uop_Fetch1_Real, 
	Uop_Fetch2, 
	Uop_Fetch3, 
	Uop_FetchDummy, 
	Uop_NOP, 
	Uop_JSR, 
	Uop_IncPC, 
	Uop_Abs_WRITE_STA, 
	Uop_Abs_WRITE_STX, 
	Uop_Abs_WRITE_STY, 
	Uop_Abs_WRITE_SAX, 
	Uop_Abs_READ_BIT, 
	Uop_Abs_READ_LDA, 
	Uop_Abs_READ_LDY, 
	Uop_Abs_READ_ORA, 
	Uop_Abs_READ_LDX, 
	Uop_Abs_READ_CMP, 
	Uop_Abs_READ_ADC, 
	Uop_Abs_READ_CPX, 
	Uop_Abs_READ_SBC, 
	Uop_Abs_READ_AND, 
	Uop_Abs_READ_EOR, 
	Uop_Abs_READ_CPY, 
	Uop_Abs_READ_NOP, 
	Uop_Abs_READ_LAX, 
	Uop_Abs_RMW_Stage4, 
	Uop_Abs_RMW_Stage6, 
	Uop_Abs_RMW_Stage5_INC, 
	Uop_Abs_RMW_Stage5_DEC, 
	Uop_Abs_RMW_Stage5_LSR, 
	Uop_Abs_RMW_Stage5_ROL, 
	Uop_Abs_RMW_Stage5_ASL, 
	Uop_Abs_RMW_Stage5_ROR, 
	Uop_Abs_RMW_Stage5_SLO, 
	Uop_Abs_RMW_Stage5_RLA, 
	Uop_Abs_RMW_Stage5_SRE, 
	Uop_Abs_RMW_Stage5_RRA, 
	Uop_Abs_RMW_Stage5_DCP, 
	Uop_Abs_RMW_Stage5_ISC, 
	Uop_JMP_abs, 
	Uop_ZpIdx_Stage3_X, 
	Uop_ZpIdx_Stage3_Y, 
	Uop_ZpIdx_RMW_Stage4, 
	Uop_ZpIdx_RMW_Stage6, 
	Uop_ZP_WRITE_STA, 
	Uop_ZP_WRITE_STX, 
	Uop_ZP_WRITE_STY, 
	Uop_ZP_WRITE_SAX, 
	Uop_ZP_RMW_Stage3, 
	Uop_ZP_RMW_Stage5, 
	Uop_ZP_RMW_DEC, 
	Uop_ZP_RMW_INC, 
	Uop_ZP_RMW_ASL, 
	Uop_ZP_RMW_LSR, 
	Uop_ZP_RMW_ROR, 
	Uop_ZP_RMW_ROL, 
	Uop_ZP_RMW_SLO, 
	Uop_ZP_RMW_RLA, 
	Uop_ZP_RMW_SRE, 
	Uop_ZP_RMW_RRA, 
	Uop_ZP_RMW_DCP, 
	Uop_ZP_RMW_ISC, 
	Uop_ZP_READ_EOR, 
	Uop_ZP_READ_BIT, 
	Uop_ZP_READ_ORA, 
	Uop_ZP_READ_LDA, 
	Uop_ZP_READ_LDY, 
	Uop_ZP_READ_LDX, 
	Uop_ZP_READ_CPX, 
	Uop_ZP_READ_SBC, 
	Uop_ZP_READ_CPY, 
	Uop_ZP_READ_NOP, 
	Uop_ZP_READ_ADC, 
	Uop_ZP_READ_AND, 
	Uop_ZP_READ_CMP, 
	Uop_ZP_READ_LAX, 
	Uop_IdxInd_Stage3, 
	Uop_IdxInd_Stage4, 
	Uop_IdxInd_Stage5, 
	Uop_IdxInd_Stage6_READ_ORA, 
	Uop_IdxInd_Stage6_READ_SBC, 
	Uop_IdxInd_Stage6_READ_LDA, 
	Uop_IdxInd_Stage6_READ_EOR, 
	Uop_IdxInd_Stage6_READ_CMP, 
	Uop_IdxInd_Stage6_READ_ADC, 
	Uop_IdxInd_Stage6_READ_AND, 
	Uop_IdxInd_Stage6_READ_LAX, 
	Uop_IdxInd_Stage6_WRITE_STA, 
	Uop_IdxInd_Stage6_WRITE_SAX, 
	Uop_IdxInd_Stage6_RMW, 
	Uop_IdxInd_Stage7_RMW_SLO, 
	Uop_IdxInd_Stage7_RMW_RLA, 
	Uop_IdxInd_Stage7_RMW_SRE, 
	Uop_IdxInd_Stage7_RMW_RRA, 
	Uop_IdxInd_Stage7_RMW_ISC, 
	Uop_IdxInd_Stage7_RMW_DCP, 
	Uop_IdxInd_Stage8_RMW, 
	Uop_AbsIdx_Stage3_X, 
	Uop_AbsIdx_Stage3_Y, 
	Uop_AbsIdx_Stage4, 
	Uop_AbsIdx_WRITE_Stage5_STA, 
	Uop_AbsIdx_WRITE_Stage5_SHY, 
	Uop_AbsIdx_WRITE_Stage5_SHX, 
	Uop_AbsIdx_WRITE_Stage5_ERROR, 
	Uop_AbsIdx_READ_Stage4, 
	Uop_AbsIdx_READ_Stage5_LDA, 
	Uop_AbsIdx_READ_Stage5_CMP, 
	Uop_AbsIdx_READ_Stage5_SBC, 
	Uop_AbsIdx_READ_Stage5_ADC, 
	Uop_AbsIdx_READ_Stage5_EOR, 
	Uop_AbsIdx_READ_Stage5_LDX, 
	Uop_AbsIdx_READ_Stage5_AND, 
	Uop_AbsIdx_READ_Stage5_ORA, 
	Uop_AbsIdx_READ_Stage5_LDY, 
	Uop_AbsIdx_READ_Stage5_NOP, 
	Uop_AbsIdx_READ_Stage5_LAX, 
	Uop_AbsIdx_READ_Stage5_ERROR, 
	Uop_AbsIdx_RMW_Stage5, 
	Uop_AbsIdx_RMW_Stage7, 
	Uop_AbsIdx_RMW_Stage6_ROR, 
	Uop_AbsIdx_RMW_Stage6_DEC, 
	Uop_AbsIdx_RMW_Stage6_INC, 
	Uop_AbsIdx_RMW_Stage6_ASL, 
	Uop_AbsIdx_RMW_Stage6_LSR, 
	Uop_AbsIdx_RMW_Stage6_ROL, 
	Uop_AbsIdx_RMW_Stage6_SLO, 
	Uop_AbsIdx_RMW_Stage6_RLA, 
	Uop_AbsIdx_RMW_Stage6_SRE, 
	Uop_AbsIdx_RMW_Stage6_RRA, 
	Uop_AbsIdx_RMW_Stage6_DCP, 
	Uop_AbsIdx_RMW_Stage6_ISC, 
	Uop_IncS, 
	Uop_DecS, 
	Uop_PushPCL, 
	Uop_PushPCH, 
	Uop_PushPCH_B, 
	Uop_PushP, 
	Uop_PullP, 
	Uop_PullPCL, 
	Uop_PullPCH_NoInc, 
	Uop_PushA, 
	Uop_PullA_NoInc, 
	Uop_PullP_NoInc, 
	Uop_PushP_BRK, 
	Uop_PushP_NMI, 
	Uop_PushP_IRQ, 
	Uop_PushP_Reset, 
	Uop_PushDummy, 
	Uop_FetchPCLVector, 
	Uop_FetchPCHVector, 
	Uop_Imp_ASL_A, 
	Uop_Imp_ROL_A, 
	Uop_Imp_ROR_A, 
	Uop_Imp_LSR_A, 
	Uop_Imp_SEC, 
	Uop_Imp_CLI, 
	Uop_Imp_SEI, 
	Uop_Imp_CLD, 
	Uop_Imp_CLC, 
	Uop_Imp_CLV, 
	Uop_Imp_SED, 
	Uop_Imp_INY, 
	Uop_Imp_DEY, 
	Uop_Imp_INX, 
	Uop_Imp_DEX, 
	Uop_Imp_TSX, 
	Uop_Imp_TXS, 
	Uop_Imp_TAX, 
	Uop_Imp_TAY, 
	Uop_Imp_TYA, 
	Uop_Imp_TXA, 
	Uop_Imm_CMP, 
	Uop_Imm_ADC, 
	Uop_Imm_AND, 
	Uop_Imm_SBC, 
	Uop_Imm_ORA, 
	Uop_Imm_EOR, 
	Uop_Imm_CPY, 
	Uop_Imm_CPX, 
	Uop_Imm_ANC, 
	Uop_Imm_ASR, 
	Uop_Imm_ARR, 
	Uop_Imm_LXA, 
	Uop_Imm_AXS, 
	Uop_Imm_LDA, 
	Uop_Imm_LDX, 
	Uop_Imm_LDY, 
	Uop_Imm_Unsupported, 
	Uop_NZ_X, 
	Uop_NZ_Y, 
	Uop_NZ_A, 
	Uop_RelBranch_Stage2_BNE, 
	Uop_RelBranch_Stage2_BPL, 
	Uop_RelBranch_Stage2_BCC, 
	Uop_RelBranch_Stage2_BCS, 
	Uop_RelBranch_Stage2_BEQ, 
	Uop_RelBranch_Stage2_BMI, 
	Uop_RelBranch_Stage2_BVC, 
	Uop_RelBranch_Stage2_BVS, 
	Uop_RelBranch_Stage2, 
	Uop_RelBranch_Stage3, 
	Uop_RelBranch_Stage4, 
	Uop__Eor, 
	Uop__Bit, 
	Uop__Cpx, 
	Uop__Cpy, 
	Uop__Cmp, 
	Uop__Adc, 
	Uop__Sbc, 
	Uop__Ora, 
	Uop__And, 
	Uop__Anc, 
	Uop__Asr, 
	Uop__Arr, 
	Uop__Lxa, 
	Uop__Axs, 
	Uop_AbsInd_JMP_Stage4, 
	Uop_AbsInd_JMP_Stage5, 
	Uop_IndIdx_Stage3, 
	Uop_IndIdx_Stage4, 
	Uop_IndIdx_READ_Stage5, 
	Uop_IndIdx_WRITE_Stage5, 
	Uop_IndIdx_WRITE_Stage6_STA, 
	Uop_IndIdx_WRITE_Stage6_SHA, 
	Uop_IndIdx_READ_Stage6_LDA, 
	Uop_IndIdx_READ_Stage6_CMP, 
	Uop_IndIdx_READ_Stage6_ORA, 
	Uop_IndIdx_READ_Stage6_SBC, 
	Uop_IndIdx_READ_Stage6_ADC, 
	Uop_IndIdx_READ_Stage6_AND, 
	Uop_IndIdx_READ_Stage6_EOR, 
	Uop_IndIdx_READ_Stage6_LAX, 
	Uop_IndIdx_RMW_Stage5, 
	Uop_IndIdx_RMW_Stage6, 
	Uop_IndIdx_RMW_Stage7_SLO, 
	Uop_IndIdx_RMW_Stage7_RLA, 
	Uop_IndIdx_RMW_Stage7_SRE, 
	Uop_IndIdx_RMW_Stage7_RRA, 
	Uop_IndIdx_RMW_Stage7_ISC, 
	Uop_IndIdx_RMW_Stage7_DCP, 
	Uop_IndIdx_RMW_Stage8, 
	Uop_End, 
	Uop_End_ISpecial, 
	Uop_End_BranchSpecial, 
	Uop_End_SuppressInterrupt, 
};
extern const Uop Microcode[264][8];
#endif // UOPENUM_H
