package com.cranajit.junglerun.model;

import java.time.Instant;
import java.util.Date;

public class Player {
	private Long udid;
	private String name;
	private Date dob;
	private Long score;
	private Instant instant;
	private Boolean joinLeaderBoard;
	
	public Player() {
	}
	public Player(Long udid, String name, Date dob, Long score, Instant instant, Boolean joinLeaderBoard) {
		super();
		this.udid = udid;
		this.name = name;
		this.dob = dob;
		this.score = score;
		this.instant = instant;
		this.joinLeaderBoard = joinLeaderBoard;
	}
	public Long getUdid() {
		return udid;
	}
	public void setUdid(Long udid) {
		this.udid = udid;
	}
	public String getName() {
		return name;
	}
	public void setName(String name) {
		this.name = name;
	}
	public Date getDob() {
		return dob;
	}
	public void setDob(Date dob) {
		this.dob = dob;
	}
	public Long getScore() {
		return score;
	}
	public void setScore(Long score) {
		this.score = score;
	}
	public Instant getInstant() {
		return instant;
	}
	public void setInstant(Instant instant) {
		this.instant = instant;
	}
	public Boolean getJoinLeaderBoard() {
		return joinLeaderBoard;
	}
	public void setJoinLeaderBoard(Boolean joinLeaderBoard) {
		this.joinLeaderBoard = joinLeaderBoard;
	}
	
}
