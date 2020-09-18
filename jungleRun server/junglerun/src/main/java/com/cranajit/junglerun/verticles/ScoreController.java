package com.cranajit.junglerun.verticles;

import io.vertx.core.AbstractVerticle;
import io.vertx.core.Handler;
import io.vertx.core.Vertx;
import io.vertx.core.json.JsonObject;
import io.vertx.core.logging.Logger;
import io.vertx.core.logging.LoggerFactory;
import io.vertx.ext.web.Router;
import io.vertx.ext.web.RoutingContext;
import io.vertx.ext.web.handler.BodyHandler;

public class ScoreController extends AbstractVerticle {
	Logger log = LoggerFactory.getLogger(ScoreController.class);
	
	Handler<RoutingContext> getallPlayerHandler = req -> {
		req.response().end("ALL PLAYERS NAME");
	};
	
	Handler<RoutingContext> getPlayerByIdHandler = req -> {
		req.response().end("ONE PLAYER");
	};
	
	Handler<RoutingContext> addPlayer = req -> {
		JsonObject body = req.getBodyAsJson();
		System.out.println(body);
		req.response().end(body.encode());
	};
	
	Handler<RoutingContext> updateScoreHandler = req -> {
		String id = req.pathParam("id");
		JsonObject body = req.getBodyAsJson();
		req.response().end("HELLO " +id+" BODY: "+body);
	};
	
	Handler<RoutingContext> deletePlayerHandler = req -> {
		String id = req.pathParam("id");
		req.response().end("HELLO"+ id);
	};
	
	private Router getRoutes() {
		Router route = Router.router(vertx);
		route.route().handler(BodyHandler.create());
		route.get("/players").handler(getallPlayerHandler);
		route.get("/player/:id").handler(getPlayerByIdHandler);
		route.post("/player").handler(addPlayer);
		route.patch("/player/:id").handler(updateScoreHandler);
		route.delete("/player/:id").handler(deletePlayerHandler);
		return route;
	}
	
	@Override
	public void start() throws Exception {
		vertx.createHttpServer()
				.requestHandler(getRoutes())
				.listen(8888, http->{
					if(http.succeeded()) {
						log.info("server is up and running");
					}
				});
	}
	
	public static void main(String... args) {
		Vertx vertx = Vertx.vertx();
		vertx.deployVerticle(new ScoreController());
	}
}
