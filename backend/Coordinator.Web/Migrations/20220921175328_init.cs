using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Coordinator.Web.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "flow_templates",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    name = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    arcs = table.Column<string>(type: "jsonb", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_flow_templates", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "workers",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    name = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_workers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "steps",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    worker_id = table.Column<long>(type: "bigint", nullable: false),
                    index = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    timeout = table.Column<int>(type: "int", nullable: true),
                    max_retries = table.Column<int>(type: "int", nullable: true),
                    flag = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_steps", x => x.id);
                    table.ForeignKey(
                        name: "FK_steps_workers_worker_id",
                        column: x => x.worker_id,
                        principalTable: "workers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "step_instances",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    step_id = table.Column<long>(type: "bigint", nullable: false),
                    input = table.Column<string>(type: "jsonb", nullable: true),
                    output = table.Column<string>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_step_instances", x => x.id);
                    table.ForeignKey(
                        name: "FK_step_instances_steps_step_id",
                        column: x => x.step_id,
                        principalTable: "steps",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "steps_in_templates",
                columns: table => new
                {
                    template_id = table.Column<long>(type: "bigint", nullable: false),
                    step_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_steps_in_templates", x => new { x.template_id, x.step_id });
                    table.ForeignKey(
                        name: "FK_steps_in_templates_flow_templates_template_id",
                        column: x => x.template_id,
                        principalTable: "flow_templates",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_steps_in_templates_steps_step_id",
                        column: x => x.step_id,
                        principalTable: "steps",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "flow_instances",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    template_id = table.Column<long>(type: "bigint", nullable: false),
                    current_step_instance_id = table.Column<long>(type: "bigint", nullable: false),
                    completed = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: false),
                    completed_at = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_flow_instances", x => x.id);
                    table.ForeignKey(
                        name: "FK_flow_instances_flow_templates_template_id",
                        column: x => x.template_id,
                        principalTable: "flow_templates",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_flow_instances_step_instances_current_step_instance_id",
                        column: x => x.current_step_instance_id,
                        principalTable: "step_instances",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_flow_instances_current_step_instance_id",
                table: "flow_instances",
                column: "current_step_instance_id");

            migrationBuilder.CreateIndex(
                name: "IX_flow_instances_template_id",
                table: "flow_instances",
                column: "template_id");

            migrationBuilder.CreateIndex(
                name: "IX_step_instances_step_id",
                table: "step_instances",
                column: "step_id");

            migrationBuilder.CreateIndex(
                name: "ix_steps_id_index",
                table: "steps",
                columns: new[] { "id", "index" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_steps_worker_id",
                table: "steps",
                column: "worker_id");

            migrationBuilder.CreateIndex(
                name: "IX_steps_in_templates_step_id",
                table: "steps_in_templates",
                column: "step_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "flow_instances");

            migrationBuilder.DropTable(
                name: "steps_in_templates");

            migrationBuilder.DropTable(
                name: "step_instances");

            migrationBuilder.DropTable(
                name: "flow_templates");

            migrationBuilder.DropTable(
                name: "steps");

            migrationBuilder.DropTable(
                name: "workers");
        }
    }
}
